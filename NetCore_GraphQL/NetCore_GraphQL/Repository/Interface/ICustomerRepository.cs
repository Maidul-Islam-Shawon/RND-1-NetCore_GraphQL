﻿using NetCore_GraphQL.Data.Entities;
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
        void AddCustomer(CustomerVM customer);
    }
}
