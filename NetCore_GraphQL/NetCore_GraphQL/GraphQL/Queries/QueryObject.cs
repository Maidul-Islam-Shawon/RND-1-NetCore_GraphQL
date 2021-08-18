using GraphQL;
using GraphQL.Types;
using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.GraphQL.Types;
using NetCore_GraphQL.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.GraphQL.Queries
{
    public class QueryObject : ObjectGraphType
    {
        public QueryObject(ICustomerRepository customerRepository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            FieldAsync<ListGraphType<CustomerType>, ICollection<Customer>>(
                "AllCustomers",
                "List of All Customers",
                resolve:
                    context=> customerRepository.GetAllCustomersAsync()
                );

            FieldAsync<CustomerType, Customer>(
                Name="CustomerByid",
                Description ="Return a Customer based on Id",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<IdGraphType>>
                        {
                            Name="id",
                            Description="This is Unique Id of Customer"
                        }),
                resolve: 
                    context=> customerRepository.GetCustomerByIdAsync(context.GetArgument("id",Guid.Empty))
                );

            FieldAsync<ListGraphType<CustomerType>, IList<Customer>>(
                Name = "CustomerByName",
                Description = "Return a Customer based on Name",
                arguments:
                    new QueryArguments(
                        new QueryArgument<StringGraphType>
                        {
                            Name="name",
                            Description="Search by Customer Name"
                        }),
                resolve:
                    context=>customerRepository.GetCustomerByName(context.GetArgument("name",string.Empty))
                );
        }
    }
}
