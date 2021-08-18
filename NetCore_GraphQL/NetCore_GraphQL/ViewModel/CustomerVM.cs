using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.ViewModel
{
    public class CustomerVM
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
