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

            //... Query: Return all Customers Details ....//
            FieldAsync<ListGraphType<CustomerType>, ICollection<Customer>>(
                "AllCustomers",
                "List of All Customers",
                resolve:
                    context=> customerRepository.GetAllCustomersAsync()
                );

            //... Query: Get Customer Detail By Id ....//
            FieldAsync<CustomerType, Customer>(
                "CustomerByid",
                "Return a Customer based on Id",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<IdGraphType>>
                        {
                            Name="id",
                            Description="This is Unique Id of Customer"
                        }),
                resolve:
                    context =>
                    {
                        var id = context.GetArgument("id", Guid.Empty);
                        return customerRepository.GetCustomerByIdAsync(id);
                    } 
                    
                    
                );

            //... Query: Get Customer Detail By name ....//
            FieldAsync<ListGraphType<CustomerType>, IList<Customer>>(
                "CustomerByName",
                "Return a Customer based on Name",
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
