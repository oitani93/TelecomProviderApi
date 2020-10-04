using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TelecomProviderApi.Controllers;
using TelecomProviderApi.Models;
using TelecomProviderApi.Services.Interface;

namespace TelecomProviderApi.Test
{
    [TestFixture]
    public class TelecomProviderTest
    {
        private Mock<ICustomersContactService> _customersContactService;
        private int id;

        private void SetUp()
        {
            id = 1;
            _customersContactService = new Mock<ICustomersContactService>();
            _customersContactService.Setup(x => x.GetAllCustomersContactRecordsAsync()).ReturnsAsync(GetData());
            _customersContactService.Setup(x => x.GetCustomersContactRecordsAsync(id)).ReturnsAsync(GetData().Where(x => x.Id == id).First());
        }

        [Test]
        public async Task GetAllCustomerContactNumbers()
        {
            SetUp();
            var controller = new CustomerContactNumberController(_customersContactService.Object);
            var actionResult = await controller.GetAllCustomersContactRecordsAsync();

            Assert.NotNull(actionResult);
            var result = actionResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public async Task GetCustomerContactNumbers()
        {
            SetUp();
            var controller = new CustomerContactNumberController(_customersContactService.Object);
            var actionResult = await controller.GetContactNumbersAsync(id);

            Assert.NotNull(actionResult);
            var result = actionResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            var model = result.Value as CustomerContactModel;
            Assert.AreEqual(id, model.Id);
        }

        private IEnumerable<CustomerContactModel> GetData()
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
