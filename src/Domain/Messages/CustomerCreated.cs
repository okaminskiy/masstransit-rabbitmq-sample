using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Messages
{
    public class CustomerCreated
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
    }
}
