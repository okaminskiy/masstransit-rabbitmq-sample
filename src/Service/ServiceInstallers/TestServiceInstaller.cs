﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain.RepositoryInstallers;

namespace Service.ServiceInstallers
{
    class TestServiceInstaller:IWindsorInstaller
    {
        //TODO: oleg - Install service for working with FakeRepository
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new TestRepositoryInstaller());
        }
    }
}
