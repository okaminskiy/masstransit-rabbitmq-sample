using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using Test.Customers.PageModels;

namespace Test.Customers.Steps
{
    [Binding]
    public class StepsBase
    {
        protected static IWindsorContainer Container;
        private static Process _serviceProcess;

        [BeforeTestRun]
        public static void BeforeRun() 
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<IWebDriver>().ImplementedBy<PhantomJSDriver>());
            Container.Register(AllTypes.FromThisAssembly().BasedOn<BasePage>());
        }

        public void RegisterContainer<TPage, TDriver>() where TPage:BasePage where TDriver: IWebDriver
        {
            
        }

        [AfterTestRun]
        public static void Cleanup()
        {
            _serviceProcess.Kill();
            Process.GetProcessesByName("PhantomJs").ToList().ForEach(p => p.Kill());
        }
    }
}
