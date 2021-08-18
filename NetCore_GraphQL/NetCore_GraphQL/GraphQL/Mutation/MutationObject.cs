using GraphQL.Types;
using NetCore_GraphQL.GraphQL.Types;
using NetCore_GraphQL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.GraphQL.Mutation
{
    public class MutationObject : ObjectGraphType
    {
        //public MutationObject(ICustomerRepository customerRepository)
        //{
        //    Name = "Mutations";
        //    Description = "The base mutation for all the entities in our object graph.";

        //    FieldAsync(
        //        arguments:
        //        new QueryArguments(
        //            new QueryArgument<NonNullGraphType<CustomerInputType>>
        //            {
        //                Name = "CreateCustomer",
        //                Description = "Add a new Customer"
        //            }),
        //        resolve:
        //            context=>
        //            {
        //               // var id = context.GetArgument<Guid>("id");
        //                var review = context.GetArgument<Review>("review");
        //                return customerRepository.AddCustomer()
        //            }
        //        );
        //}
    }
}
