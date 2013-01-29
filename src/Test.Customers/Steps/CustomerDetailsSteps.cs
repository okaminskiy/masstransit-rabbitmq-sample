
using System.Diagnostics;
using System.Linq;
using Castle.Windsor;
using Domain.Documents;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Domain.RepositoryInstallers;
using Test.Customers.PageModels;

namespace Test.Customers.Steps
{
    [Binding]
    public class CustomerDetailsSteps
    {
        private CustomerDetailsPage _page;
        private IWindsorContainer _container ;
        private Process _serviceProcess;

        [Given(@"I open the details page")]
        public void OpenPage()
        {
            _serviceProcess = Process.Start("..\\..\\..\\..\\output\\service\\service.exe");
            _container = new WindsorContainer();
            _container.Install(new RealRepositoriesInstaller());
            _page = new CustomerDetailsPage();
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
            ICustomerDetailsRepository rep = _container.Resolve<ICustomerDetailsRepository>();
            CustomerDetails cd =
                rep.GetAll().FirstOrDefault(d => d.FirstName == _page.FirstName && d.LastName == _page.LastName);
            Assert.IsNotNull(cd);
            rep.Delete(cd);
            return;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _serviceProcess.Close();
        }
    }
}
