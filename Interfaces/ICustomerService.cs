using System;

namespace Basic_Crud
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomers();
        Task<CustomerAddressViewModel> CreateCustomer(CustomerAddressViewModel obj);
        Task<CustomerAddressViewModel> getCustomerById(int id);
        Task<bool> deleteCustomerById(int id);
        Task<CustomerAddressViewModel> UpdateCustomerById(int id, CustomerAddressViewModel obj);
    }
}
