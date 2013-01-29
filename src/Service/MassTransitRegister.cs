using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using MassTransit.Saga;

namespace Service
{
    public class MassTransitRegister
    {
        //TODO: oleg - look how to use DI for Bus installation in the elevate Project
        public static void MTRegister(IWindsorContainer container)
        {
            container.Register(AllTypes.FromThisAssembly().BasedOn<IConsumer>().LifestyleTransient());

            container.Register(Component.For(typeof(ISagaRepository<>)).ImplementedBy(typeof(InMemorySagaRepository<>)));
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                // this should be different from other endpoints in the project
                sbc.ReceiveFrom("rabbitmq://localhost/sample.service");
                sbc.Subscribe(subs =>
                {
                    subs.LoadFrom(container);
                    subs.Saga<CustomerSaga>(container);
                });
            });
        }
    }
}
