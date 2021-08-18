using GraphQL;
using GraphQL.Types;
using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.GraphQL.Types;
using NetCore_GraphQL.Repository.Interface;
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
            Description = "The base mutation for all the entities in our object graph.";

            Field<CustomerType>(
                Name = "Customer_Create",
                Description = "Create a new Customer",

                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>>
                    {
                        Name = "CreateCustomer",
                        Description = "Add a new Customer"
                    }),
                resolve:
                    context =>
                    {
                        var customer = context.GetArgument<Customer>("Customer");
                        return customerRepository.AddCustomer(customer);
                    }
                );
        }
    }
}
