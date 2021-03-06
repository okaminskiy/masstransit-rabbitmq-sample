﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain.Repositories;

namespace Domain.RepositoryInstallers
{
    public class TestRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICustomerDetailsRepository>().ImplementedBy<TestCustomerDetailsRepository>().LifestyleTransient());
        }
    }
}
