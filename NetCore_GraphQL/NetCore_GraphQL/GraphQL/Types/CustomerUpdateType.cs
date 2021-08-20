using GraphQL.Types;
using NetCore_GraphQL.Data.Entities;
using NetCore_GraphQL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.GraphQL.Types
{
    public class CustomerUpdateType : InputObjectGraphType<CustomerVM>
    {
        public CustomerUpdateType()
        {
            Name = "CustomerUpdate";     //Name of Input Type
            Description = "Update Customer Information";  //Description of Input Type

            //...include fields which will be use as input field...//
            Field(a => a.Name, nullable:true).Description("Name of the Customer");
            Field(a => a.Age, nullable: true).Description("Age of the Customer");
            Field(a => a.Email, nullable: true).Description("Email of the Customer");
            Field(a => a.ContactNumber, nullable: true).Description("Contact Number of the Cusomer");
            Field(a => a.Address, nullable: true).Description("Address of the Customer");
        }
    }
}
