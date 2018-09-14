using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelecomProviderApi.Services.Interface;

namespace TelecomProviderApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerContactNumberController : Controller
    {
        private readonly ICustomersContactService _customersContactService;

        public CustomerContactNumberController(ICustomersContactService customersContactService)
        {
            _customersContactService = customersContactService;
        }

        [HttpGet("GetAllCustomersContactRecords")]
        public async Task<IActionResult> GetAllCustomersContactRecordsAsync()
        {
            var respone = await _customersContactService.GetAllCustomersContactRecordsAsync();
            return Ok(respone);
        }

        // GET Customer Numbers
        [HttpGet("GetCustomerContactNumbers/{id}")]
        public async Task<IActionResult> GetContactNumbersAsync(int id)
        {
            var respone = await _customersContactService.GetCustomersContactRecordsAsync(id);
            return Ok(respone);
        }

        [HttpPost("ActivateContactNumber/{id}/{type}")]
        public async Task<IActionResult> ActivateContactNumberAsync(int id, string type, string number)
        {
            var response = await _customersContactService.ActivateCustomersContactNumberAsync(id, type, number);
            if (response)
            {
                return Ok("Number Active!");
            }
            else
            {
                return BadRequest("Number not found! Please Try Again!");
            }
        }
    }
}
