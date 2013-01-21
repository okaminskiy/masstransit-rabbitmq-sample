using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Messages;
using MassTransit;

namespace Customers.Subscribers
{
    public class CustomerDetailsSubscriber : Consumes<CustomerDetails>.All
    {
        public void Consume(CustomerDetails message)
        {
            throw new NotImplementedException();
        }
    }
}