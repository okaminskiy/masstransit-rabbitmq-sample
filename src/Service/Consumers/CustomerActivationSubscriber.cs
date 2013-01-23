using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
using MassTransit;

namespace Service.Consumers
{
        public class CustomerActivationSubscriber : Consumes<ActivateCustomerCommand>.All
        {
           

            public void ParseCv(string name)
            {
                Console.WriteLine(name);
            }
                

            public void Consume(ActivateCustomerCommand message)
            {
                ParseCv(message.S3Key);
            }
        }
}
