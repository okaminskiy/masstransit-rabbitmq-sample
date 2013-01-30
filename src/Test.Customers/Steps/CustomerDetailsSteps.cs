
using System.Diagnostics;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.Documents;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using Domain.RepositoryInstallers;
using Test.Customers.PageModels;

namespace Test.Customers.Steps
{
    [Binding]
    public class CustomerDetailsSteps: StepsBase
    {

        private CustomerDetailsPage _page;
        [Given(@"I open the details page")]
        public void OpenPage()
        {
            Container.Install(new RealRepositoriesInstaller());
            _page = Container.Resolve<CustomerDetailsPage>();
        }

        [When(@"I input")]
        public void Input(Table table)
        {
            _page.Age = table.Rows[0]["Age"];
            _page.FirstName = table.Rows[0]["FirstName"];
            _page.LastName = table.Rows[0]["LastName"];
            _page.Location = table.Rows[0]["Location"];
        }

        [When(@"I press submit")]
        public void Submit()
        {
            _page.Submit();
        }

        [Then(@"the result should be success on the screen")]
        public void CheckResult()
        {
            Assert.AreEqual(_page.ResultMessage, "Sent");
        }

        [Then(@"my details added to DataBase")]
        public void CheckResultInDb()
        {
            ICustomerDetailsRepository rep = Container.Resolve<ICustomerDetailsRepository>();
            CustomerDetails cd =
                rep.GetAll().FirstOrDefault(d => d.FirstName == _page.FirstName && d.LastName == _page.LastName);
            Assert.IsNotNull(cd);
            rep.Delete(cd);
        }
    }
}
