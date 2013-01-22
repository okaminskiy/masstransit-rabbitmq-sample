using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
namespace Domain.MongoDb
{
    public class CustomerDetailsRepository: ICustomerDetailsRepository
    {
        public CustomerDetails GetCustomerDetails()
        {
           return MongoRepository.Database.GetCollection<CustomerDetails>("Details").FindAll().First();
        }

        public void AddCustomerDetails(CustomerDetails customer)
        {
            var customersDetails = MongoRepository.Database.GetCollection<CustomerDetails>("Details");
            customersDetails.Insert(customer);
        }

        public void Drop()
        {
            MongoRepository.Database.GetCollection<CustomerDetails>("Details").Drop();
        }
    }
}
