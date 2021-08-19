using GraphQL;
using GraphQL.Types;
using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.GraphQL.Types;
using NetCore_GraphQL.Repository.Interface;
using NetCore_GraphQL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.GraphQL.Mutation
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(ICustomerRepository customerRepository)
        {
            Name = "Mutations";
            Description = "The base Mutation for all the entities in our object graph.";

            //... Create a New Customer ...//
            FieldAsync<CustomerType>(
                "CreateCustomer",
                "Create a new Customer",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<CustomerInputType>>
                        {
                            Name = "customer"
                        }),
                resolve:
                    async context =>
                    {
                        var customer = context.GetArgument<Customer>("customer");

                        if (customer == null)
                        {
                            context.Errors.Add(new ExecutionError("Please provide data to create a new customer"));
                            return null;
                        }

                        return await customerRepository.AddCustomer(customer);
                    }
                );


            //... Update Customer Data ...//
            FieldAsync<CustomerType>(
                "UpdateCustomer",
                "Update the Customer Details",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<IdGraphType>>
                        {
                            Name = "id",
                            Description = "Customer existing Id"
                        },
                        new QueryArgument<CustomerUpdateType>
                        {
                            Name = "customer",
                            Description = "Updated details of customer"
                        }),
                resolve:
                   async context =>
                    {
                        var Id = context.GetArgument<Guid>("id");
                        var customer = context.GetArgument<Customer>("customer");

                        var existingCustomer = await customerRepository.GetCustomerByIdAsync(Id);

                        if (existingCustomer == null)
                        {
                            context.Errors.Add(new ExecutionError("Couldn't find the customer in DB"));
                            return null;
                        }

                        existingCustomer.Name = customer.Name == null ? existingCustomer.Name : customer.Name;
                        existingCustomer.Email = customer.Email == null ? existingCustomer.Email : customer.Email;
                        existingCustomer.ContactNumber = customer.ContactNumber == null ? existingCustomer.ContactNumber : customer.ContactNumber;
                        existingCustomer.Address = customer.Address == null ? existingCustomer.Address : customer.Address;
                        existingCustomer.Age = customer.Age == 0 ? existingCustomer.Age : customer.Age;

                        return await customerRepository.UpdateCustomer(existingCustomer);
                    }
                );

            //... Delete a Customer from DB ...//
            FieldAsync<StringGraphType>(
                "DeleteCustomer",
                "Delete a Customer from Database",

                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<IdGraphType>>
                        {
                            Name = "id"
                        }),
                resolve:
                    async context =>
                    {
                        var id = context.GetArgument<Guid>("id");

                        var customer = await customerRepository.GetCustomerByIdAsync(id);

                        if (customer == null)
                        {
                            context.Errors.Add(new ExecutionError("Couldn't find the customer in DB"));
                            return null;
                        }

                        await customerRepository.DeleteCustomer(customer);
                        return $"Customer deleted successfully";
                    }
                );

        }
    }
}
