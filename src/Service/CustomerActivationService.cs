using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
using MassTransit;

namespace Service
{
        public class CustomerActivationSubscriber : Consumes<ActivateCustomerCommand>.Context
        {
           

            public void ParseCv(string name)
            {
                Console.WriteLine(name);
            }

            public void Consume(IConsumeContext<ActivateCustomerCommand> context)
            {
                ParseCv(context.Message.S3Key);
            }
        }
}
