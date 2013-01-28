using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Domain.Messages;
using DD = Domain.Documents;
using Domain.Repositories;
using MassTransit;

namespace Service.Consumers
{

    public class CustomerDetailsSubscriber : Consumes<CustomerDetails>.All
    {
        private readonly ICustomerDetailsRepository _repository;
        public CustomerDetailsSubscriber(ICustomerDetailsRepository repository)
        {
            if (repository == null)
            {
                throw new NullReferenceException("CustomerDetails repository");
            }
            _repository = repository;
        }

        public void Consume(CustomerDetails message)
        {
            Console.WriteLine("Saved in database " + _repository.GetType().Name );
           _repository.Add(new Domain.Documents.CustomerDetails
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
