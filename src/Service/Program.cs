using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using MassTransit.Saga;
using Topshelf;


namespace Service
{
    public class Program
    {
       
        public static WindsorContainer Container;
        //Never It's Example how to use MassTransit Windsor 
        public static void Main(string[] args)
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<Service>());   
            Container.Register(AllTypes.FromThisAssembly().BasedOn<IConsumer>());
            Container.Register(Component.For(typeof(ISagaRepository<>)).ImplementedBy(typeof(InMemorySagaRepository<>)));
            
            Bus.Initialize(sbc =>
                {
                    sbc.UseRabbitMq();
                    sbc.UseRabbitMqRouting();
                    // this should be different from other endpoints in the project
                    sbc.ReceiveFrom("rabbitmq://localhost/elevate.service");
                    sbc.Subscribe(subs =>
                        {
                            subs.LoadFrom(Container);
                            subs.Saga<CustomerSaga>(Container);
                        });
                });

 

            var cfg = HostFactory.New(c => {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");
                c.Service<Service>(a =>
                {
                    a.ConstructUsing(service => Container.Resolve<Service>());
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
