using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<IList<Customer>> GetCustomerByName(string name);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Guid id, CustomerVM updatedCustomerData);
        Task DeleteCustomer(Customer customer);
    }
}
