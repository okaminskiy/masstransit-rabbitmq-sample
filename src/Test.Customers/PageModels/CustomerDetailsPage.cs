using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Test.Customers.PageModels
{
    public class CustomerDetailsPage
    {
        private readonly IWebDriver _driver;

        private readonly string _url = "http://localhost:21634/customerdetails"; 

        public CustomerDetailsPage ()
        {
            _driver = new PhantomJSDriver();
            _driver.Navigate().GoToUrl("http://localhost:21634/customerdetails");
        }

        public void UseDriver(IWebDriver driver)
        {
           IWebDriver _driver;
        }

        public string FirstName
        {
            set { _driver.FindElement(By.Id("FirstName")).SendKeys(value); }
            get { return _driver.FindElement(By.Id("FirstName")).GetAttribute("value"); }
        }

        public string LastName
        {
            set { _driver.FindElement(By.Id("LastName")).SendKeys(value); }
            get { return _driver.FindElement(By.Id("LastName")).GetAttribute("value"); }
        }

        public string EmailAddress
        {
            set { _driver.FindElement(By.Id("EmailAddress")).SendKeys(value); }
        }

        public string Age
        {
            set { _driver.FindElement(By.Id("Age")).SendKeys(value); }
        }

        public string Location
        {
            set { _driver.FindElement(By.Id("Location")).SendKeys(value); }
        }

        public string ResultMessage
        {
            get { return _driver.FindElement(By.Id("result")).Text; }
        }

        public void Submit()
        {
            _driver.FindElement(By.Id("Submit")).Submit();
        }
    }
}


public class CustomerDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }