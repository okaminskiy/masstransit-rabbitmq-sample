using System;
using Domain.Messages;
using MassTransit;

namespace Customers.Subscribers
{
    public class AuthorizeCustomerSubscriber : Consumes<CustomerCreated>.All
    {

        public void Consume(CustomerCreated message)
        {
            Bus.Instance.Publish(new AuthorizeCustomer { Email = message.Email, CustomerId = message.CustomerId });
        }
    }
}