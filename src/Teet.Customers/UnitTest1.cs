using System;
using System.Diagnostics;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.Documents;
using Domain.Repositories;
using Domain.WindsorInstallers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Teet.Customers
{
    [TestClass]
    public class UnitTest1
    {
        static Process _serviceProcess;
        public ICustomerDetailsRepository Repository;
        
        public static IWindsorContainer Container;
        
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            /*container.Register(Component.For<IRepository<CustomerDetails>>().LifeStyle.Transient
                                                     .ImplementedBy<TestCustomerDetailsRepository>());*/
        }

        [TestInitialize]
        public void Init()
        {
            Container = new WindsorContainer();  
            Container.Install(new RealRepositoriesInstaller());
            Repository = Container.Resolve<ICustomerDetailsRepository>();
            Repository.Drop();
        }

        [TestMethod]
        public void TestCustomerDetails()
        {
            var driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("http://localhost:21634/customerdetails");
            Type type = new CustomerDetails().GetType();

            IWebElement element;
            foreach (var property in type.GetProperties())
            {
                if(property.Name == "Id") { continue; }
                element = driver.FindElementById(property.Name);
                element.SendKeys(property.Name);
            }

            element = driver.FindElement(By.Id("Submit"));
            element.Submit();
            element = driver.FindElementById("result");
            Assert.IsTrue(element.Text == "Sent");

            System.Threading.Thread.Sleep(10000); 
            
            CustomerDetails customer = Repository.GetAll().First();
            foreach (var property in customer.GetType().GetProperties())
            {
                if (property.Name == "Id") { continue; }
                if (property.Name == "Age") {
                    Assert.IsTrue(((int)property.GetValue(customer, null)) == 0); 
                    continue; 
                }
                Assert.IsTrue(((string) property.GetValue(customer, null)) == property.Name);
            }

        }
        
    }
}
