using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain.Documents;
using Domain.Repositories;

namespace Domain.WindsorInstallers
{
    public class RealRepositoriesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICustomerDetailsRepository>().ImplementedBy<CustomerDetailsRepository>().LifeStyle.Transient);
        }
    }
}
