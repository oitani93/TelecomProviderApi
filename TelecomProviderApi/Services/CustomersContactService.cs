using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelecomProviderApi.Models;
using TelecomProviderApi.Services.Interface;

namespace TelecomProviderApi.Services
{
    public class CustomersContactService : ICustomersContactService
    {
        public Task<IEnumerable<CustomerContactModel>> GetAllCustomersContactRecordsAsync()
            => Task.FromResult(GetAllCustomers());

        public Task<CustomerContactModel> GetCustomersContactRecordsAsync(int id)
            => Task.FromResult(GetAllCustomers().Where(x => x.Id == id).FirstOrDefault());

        public Task<bool> ActivateCustomersContactNumberAsync(int id, string type, string number)
        {
            var model = GetAllCustomers()
                .Where(x => x.Id == id)
                .FirstOrDefault()?.ContactNumbers
                .Where(x => x.Type == type)
                .FirstOrDefault();

            if (model == null || (string.IsNullOrEmpty(model.Number) && string.IsNullOrEmpty(number)))
            {
                return Task.FromResult(false);
            }
            else
            {
                model.Number = number ?? model.Number;
                model.NumberActive = true;
                return Task.FromResult(true);
            }
        }

        private IEnumerable<CustomerContactModel> GetAllCustomers()
        {
            var customer_one = new CustomerContactModel
            {
                Id = 1,
                Title = "Mr",
                FirstName = "Omar",
                LastName = "Itani",
                ContactNumbers = new List<ContactNumberModel>
                {
                    new ContactNumberModel { Number = "0123456789", NumberActive = true, Type = NumberType.MOBILE },
                    new ContactNumberModel { Number = "3456789012", NumberActive = true, Type = NumberType.WORK },
                    new ContactNumberModel { Number = "6789012345", NumberActive = false, Type = NumberType.HOME },
                    new ContactNumberModel { Number = "8901234567", NumberActive = true, Type = NumberType.OTHER }
                }
            };

            var customer_two = new CustomerContactModel
            {
                Id = 2,
                Title = "Mrs",
                FirstName = "Linda",
                LastName = "Mason",
                ContactNumbers = new List<ContactNumberModel>
                {
                    new ContactNumberModel { Number = "0123433389", NumberActive = false, Type = NumberType.MOBILE },
                    new ContactNumberModel { Number = "3456555012", NumberActive = false, Type = NumberType.WORK },
                    new ContactNumberModel { Number = "6789999345", NumberActive = false, Type = NumberType.HOME },
                    new ContactNumberModel { Number = "8901234122", NumberActive = true, Type = NumberType.OTHER }
                }
            };

            var customer_three = new CustomerContactModel
            {
                Id = 3,
                Title = "Mr",
                FirstName = "Adam",
                LastName = "Loftus",
                ContactNumbers = new List<ContactNumberModel>
                {
                    new ContactNumberModel { Number = "0123223389", NumberActive = false, Type = NumberType.MOBILE },
                    new ContactNumberModel { Number = "3454455012", NumberActive = false, Type = NumberType.WORK },
                    new ContactNumberModel { Number = "6889999345", NumberActive = true, Type = NumberType.HOME },
                    new ContactNumberModel { Number = "8901234002", NumberActive = true, Type = NumberType.OTHER }
                }
            };
            return new List<CustomerContactModel> { customer_one, customer_two, customer_three };
        }
    }
}
