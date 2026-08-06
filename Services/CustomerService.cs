using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    public class CustomerService: ICustomerService
    {
        public readonly EmployeeDbContextClass _dbContext;

        public CustomerService(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            var customers = await _dbContext.CustomerModels.ToListAsync();
            return customers;

        }

        public async Task<CustomerAddressViewModel> CreateCustomer(CustomerAddressViewModel obj)
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
            return obj;

        }

        public async Task<CustomerAddressViewModel> getCustomerById(int id)
        {
            var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m => m.custId == id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
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
                return customerViewModel;
            }

        }

        public async Task<bool> deleteCustomerById(int id)
        {
            var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m => m.custId == id);
            if (customer == null)
            {
                return false; // Customer not found
            }
            else
            {
                var addresses = await _dbContext.CustomerAddressModels.Where(a => a.custId == id).ToListAsync();
                _dbContext.CustomerAddressModels.RemoveRange(addresses);
                _dbContext.CustomerModels.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true; // Customer and associated addresses deleted successfully
            }

        }

        public async Task<CustomerAddressViewModel> UpdateCustomerById(int id, CustomerAddressViewModel obj)
        {
            var customer = await _dbContext.CustomerModels.SingleOrDefaultAsync(m => m.custId == id);
            if (customer == null)
            {
                return null; // Customer not found
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
                return obj; // Return the updated customer view model
            }

        }

    }
}
