using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;

namespace Domain.MongoDb
{
    public interface ICustomerDetailsRepository
    {
        CustomerDetails GetCustomerDetails();
        void AddCustomerDetails(CustomerDetails customer);
        void Drop();
    }
}
