using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Test.Customers.PageModels
{
    public class CustomerDetailsPage: BasePage
    {
        //TODO: oleg - push it to app.config
        private const string Url = "http://localhost:4000/Customers/customerdetails";

        public CustomerDetailsPage(IWebDriver driver) : base(driver, Url)
        {}

        public string FirstName
        {
            set { Driver.FindElement(By.Id("FirstName")).SendKeys(value); }
            get { return Driver.FindElement(By.Id("FirstName")).GetAttribute("value"); }
        }

        public string LastName
        {
            set { Driver.FindElement(By.Id("LastName")).SendKeys(value); }
            get { return Driver.FindElement(By.Id("LastName")).GetAttribute("value"); }
        }

        public string EmailAddress
        {
            set { Driver.FindElement(By.Id("EmailAddress")).SendKeys(value); }
        }

        public string Age
        {
            set { Driver.FindElement(By.Id("Age")).SendKeys(value); }
        }

        public string Location
        {
            set { Driver.FindElement(By.Id("Location")).SendKeys(value); }
        }

        public string ResultMessage
        {
            get { return Driver.FindElement(By.Id("result")).Text; }
        }

        public void Submit()
        {
            Driver.FindElement(By.Id("Submit")).Submit();
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