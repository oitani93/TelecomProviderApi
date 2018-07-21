using System.Collections.Generic;
using System.Threading.Tasks;
using TelecomProviderApi.Models;

namespace TelecomProviderApi.Services.Interface
{
    public interface ICustomersContactService
    {
        Task<IEnumerable<CustomerContactModel>> GetAllCustomersContactRecordsAsync();

        Task<CustomerContactModel> GetCustomersContactRecordsAsync(int id);

        Task<bool> ActivateCustomersContactNumberAsync(int id, string type, string number);
    }
}
