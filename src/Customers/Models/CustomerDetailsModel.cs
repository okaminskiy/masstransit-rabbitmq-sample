using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customers.Models
{
    public class CustomerDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}