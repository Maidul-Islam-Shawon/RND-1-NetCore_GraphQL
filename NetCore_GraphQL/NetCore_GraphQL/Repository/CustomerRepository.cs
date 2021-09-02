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
            _context.Database.EnsureCreated();  //Database will create
        }

        //....below function will return all customers from database......//
        public async Task<ICollection<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        //....below function will return single customer by id from database......//
        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _context.Customer.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        //....below function will return single customer by name from database......//
        public async Task<IList<Customer>> GetCustomerByName(string name)
        {
            return await _context.Customer.Where(a => a.Name.Contains(name)).ToListAsync();
        }

        //....below function to create a new customer......//
        public async Task<Customer> AddCustomer(Customer customer)
        {

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        //....below function to Update a existing customer data......//
        public async Task<Customer> UpdateCustomer(Guid id, CustomerVM updatedCustomerData)
        {
            try
            {
                var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

                if (customer != null)
                {
                    _context.Entry(customer).CurrentValues.SetValues(updatedCustomerData);
                    await _context.SaveChangesAsync();
                    return customer;
                }
                
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //....below function to delete a new customer......//
        public async Task DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
