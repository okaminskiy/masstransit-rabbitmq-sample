using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;
using MongoDB.Driver;

namespace Domain.Repositories
{
    public class CustomerDetailsRepository: MongoRepository<CustomerDetails>, ICustomerDetailsRepository
    {
        public CustomerDetailsRepository():base("Details")
        {}

        public override List<CustomerDetails> GetAll()
        {
            return _collection.FindAll().ToList();
        }
    }
}
