using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.Messages;

namespace Web.CastleWindsor
{
    public static class Windsor
    {
        private static readonly IWindsorContainer _container;

        public static void RegisterDependency()
        {
            _container.Register(Component.For<AuthorizeCustomer>().LifeStyle.Transient,
                Component.For<CreateCustomer>().LifeStyle.Transient,
                Component.For<CustomerCreated>().LifeStyle.Transient);
        }
    }
}