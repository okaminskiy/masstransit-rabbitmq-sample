using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.Messages;
using MassTransit;
using MassTransit.Saga;
using Topshelf;


namespace Service
{
    public class Program
    {
       
        public static WindsorContainer Container;

        public static void Main(string[] args)
        {
            Container = new WindsorContainer();
            Container.Register(AllTypes.FromThisAssembly().BasedOn<IConsumer>());
            
            Bus.Initialize(sbc =>
                {
                    sbc.UseRabbitMq();
                    sbc.UseRabbitMqRouting();
                    // this should be different from other endpoints in the project
                    sbc.ReceiveFrom("rabbitmq://localhost/elevate.service");
                    sbc.Subscribe(subs =>
                        {
                            subs.Saga(new InMemorySagaRepository<CustomerSaga>()).Permanent();
                            subs.LoadFrom(Container);
                        });
                });

            var cfg = HostFactory.New(c => {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");
                c.Service<Service>(a =>
                {
                    a.ConstructUsing(service => new Service());
                    a.WhenStarted(o => o.Start());
                    a.WhenStopped(o => o.Stop());
                });
            });
            try
            {
                cfg.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
