using GraphQL.Types;
using NetCore_GraphQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.GraphQL.Types
{
    public class CustomerInputType : ObjectGraphType<Customer>
    {
        public CustomerInputType()
        {
            Name = "CustomerInput";
            Description = "A List of Custmers data";
            
            Field(a => a.Name).Description("Name of the Customer");
            Field(a => a.Age).Description("Age of the Customer");
            Field(a => a.Email, nullable: true).Description("Email of the Customer");
            Field(a => a.ContactNumber, nullable: true).Description("Contact Number of the Cusomer");
            Field(a => a.Address).Description("Address of the Customer");
        }
    }
}
