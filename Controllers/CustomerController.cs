using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;

        public CustomerController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerAddressViewModel obj)
        {
            CustomerModel _customer = new CustomerModel()
            {
                 email = obj.email,
                 mobile = obj.mobile,
                 name = obj.name
            };
            await _dbContext.CustomerModels.AddAsync(_customer);
            await _dbContext.SaveChangesAsync();

            foreach (var address in obj.addresses)
            {
                CustomerAddressModel _customerAddress = new CustomerAddressModel()
                {
                    custId = _customer.custId,
                    address = address.address,
                    city = address.city,
                    title = address.title,
                    pincode = address.pincode
                };
                await _dbContext.CustomerAddressModels.AddAsync(_customerAddress);
                await _dbContext.SaveChangesAsync();
            }
            obj.custId = _customer.custId; // Set the custId in the response model
            return Created("Customer created successfully.", obj);
        }

        [HttpGet("getCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _dbContext.CustomerModels.ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getCustomerById/{id}")]
        public async Task<IActionResult> getCustomerById(int id)
        {
            try
            {
                var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m=> m.custId == id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    var addresses = await _dbContext.CustomerAddressModels.Where(a => a.custId == id).ToListAsync();
                    var customerViewModel = new CustomerAddressViewModel
                    {
                        custId = customer.custId,
                        name = customer.name,
                        email = customer.email,
                        mobile = customer.mobile,
                        addresses = addresses
                    };
                    return Ok(customerViewModel);
                }

            }
            catch (System.Exception ex)
            {
                
                return StatusCode(500, new {error = ex.Message});
            }
        }

        [HttpDelete("deleteCustomerById/{id}")]
        public async Task<IActionResult> deleteCustomerById(int id)
        {
            try
            {
                var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m => m.custId == id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    var addresses = await _dbContext.CustomerAddressModels.Where(a => a.custId == id).ToListAsync();
                    _dbContext.CustomerAddressModels.RemoveRange(addresses);
                    _dbContext.CustomerModels.Remove(customer);
                    await _dbContext.SaveChangesAsync();
                    return Ok($"Customer with ID {id} and associated addresses deleted successfully.");
                }

            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("updateCustomerById/{id}")]
        public async Task<IActionResult> UpdateCustomerById(int id, CustomerAddressViewModel obj)
        {
            try
            {
                var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m => m.custId == id);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    customer.name = obj.name;
                    customer.email = obj.email;
                    customer.mobile = obj.mobile;

                    var addresses = await _dbContext.CustomerAddressModels.Where(a => a.custId == id).ToListAsync();
                    _dbContext.CustomerAddressModels.RemoveRange(addresses);

                    foreach (var address in obj.addresses)
                    {
                        CustomerAddressModel _customerAddress = new CustomerAddressModel()
                        {
                            custId = customer.custId,
                            address = address.address,
                            city = address.city,
                            title = address.title,
                            pincode = address.pincode
                        };
                        await _dbContext.CustomerAddressModels.AddAsync(_customerAddress);
                    }

                    await _dbContext.SaveChangesAsync();
                    return Ok($"Customer with ID {id} updated successfully.");
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
