using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.MongoDb
{
    public interface ICustomerDetailsRepository: IRepository<CustomerDetails>
    {
        CustomerDetails Get(Guid id);

        void Add(CustomerDetails customer);

        void Drop();

        List<CustomerDetails> GetAll();
    }
}
