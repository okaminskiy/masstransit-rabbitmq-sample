using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.RepositoryInstallers;
using MassTransit;
using MassTransit.Saga;
using Service.Consumers;
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
            Container.Install(new RealRepositoriesInstaller());
           
            MassTransitRegister.MTRegister(Container);

            Container.Register(Component.For<Service>());

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
