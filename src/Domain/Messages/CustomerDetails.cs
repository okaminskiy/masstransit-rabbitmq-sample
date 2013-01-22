using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Messages
{
    public class CustomerDetails
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Age { get; set; }
        public string Location { get; set; }
    }
}
