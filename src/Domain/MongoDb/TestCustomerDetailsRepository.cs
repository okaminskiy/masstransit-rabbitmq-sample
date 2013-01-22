using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Documents;

namespace Domain.MongoDb
{
    public  class TestCustomerDetailsRepository: TestRepository<CustomerDetails>, IRepository<CustomerDetails>
    {
        static private List<CustomerDetails> _details = new List<CustomerDetails>()
                {
                    new CustomerDetails
                        {
                            Age = 14,
                            EmailAddress = "Address",
                            FirstName = "FirstName",
                            Id = Guid.NewGuid(),
                            LastName = "Lastname",
                            Location = "location"
                        },
                    new CustomerDetails
                        {
                            Age = 14,
                            EmailAddress = "Address",
                            FirstName = "FirstName",
                            Id = Guid.NewGuid(),
                            LastName = "Lastname",
                            Location = "location"
                        },
                    new CustomerDetails
                        {
                            Age = 14,
                            EmailAddress = "Address",
                            FirstName = "FirstName",
                            Id = Guid.NewGuid(),
                            LastName = "Lastname",
                            Location = "location"
                        }
                };

        private TestCustomerDetailsRepository():base(_details){}
    }
}
