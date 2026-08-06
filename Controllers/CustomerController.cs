using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<CustomerAddressViewModel> CreateCustomer(CustomerAddressViewModel obj)
        {
            var result = await _customerService.CreateCustomer(obj);
            return result;
        }

        [HttpGet("getCustomers")]
        public async Task<List<CustomerModel>> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            return customers;
        }

        [HttpGet("getCustomerById/{id}")]
        public async Task<CustomerAddressViewModel> getCustomerById(int id)
        {
            var customer = await _customerService.getCustomerById(id);
            return customer;
        }

        [HttpDelete("deleteCustomerById/{id}")]
        public async Task<bool> deleteCustomerById(int id)
        {
            var result = await _customerService.deleteCustomerById(id);
            return result;
        }

        [HttpPut("updateCustomerById/{id}")]
        public async Task<CustomerAddressViewModel> UpdateCustomerById(int id, CustomerAddressViewModel obj)
        {
            var result = await _customerService.UpdateCustomerById(id, obj);
            return result;
        }
    }
}
