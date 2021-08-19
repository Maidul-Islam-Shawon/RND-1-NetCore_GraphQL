using Microsoft.EntityFrameworkCore;
using NetCore_GraphQL.Data;
using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.Repository.Interface;
using NetCore_GraphQL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NetCoreGraphQL_Context _context;

        public CustomerRepository(NetCoreGraphQL_Context context)
        {
            this._context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<ICollection<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _context.Customer.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Customer>> GetCustomerByName(string name)
        {
            return await _context.Customer.Where(a => a.Name.Contains(name)).ToListAsync();
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer updatedCustomerData)
        {
            try
            {
                var updatedCustomer = (_context.Customer.Update(updatedCustomerData)).Entity;
                await _context.SaveChangesAsync();
                return updatedCustomer;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
