using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Messages;
using DD = Domain.Documents;
using Domain.MongoDb;
using MassTransit;

namespace Customers.Subscribers
{
    public class CustomerDetailsSubscriber : Consumes<CustomerDetails>.All
    {
        public void Consume(CustomerDetails message)
        {
            new CustomerDetailsRepository().Add(new DD.CustomerDetails
                {
                    Id = message.Id,
                    EmailAddress = message.EmailAddress,
                    Age = message.Age,
                    FirstName = message.FirstName,
                    LastName = message.LastName,
                    Location = message.Location
                });
        }
    }
}