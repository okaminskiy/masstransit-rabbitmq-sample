using System;
using System.Diagnostics;
using System.Linq;
using Domain.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.MongoDb;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Teet.Customers
{
    [TestClass]
    public class UnitTest1
    {
        static Process _serviceProcess;
        private ICustomerDetailsRepository repository;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            _serviceProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "service")
                ?? Process.Start(@"..\..\..\..\output\service\Service.exe");
        }

        [TestInitialize]
        public void Init()
        {
            repository = new CustomerDetailsRepository();
            repository.Drop();
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
            
            CustomerDetails customer = repository.GetAll().First();
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
