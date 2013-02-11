using System;
using OpenQA.Selenium;

namespace Test.Customers.PageModels
{
    public class TemplatesPage: BasePage
    {
        //TODO: oleg - push it to app.config
        //private const string Url = "http://localhost:4000/Customers/steps";
        private const string Url = "http://localhost:3333/steps";

        public TemplatesPage(IWebDriver driver) : base(driver, Url)
        {}

        public void ClickNext()
        {
            IWebElement element = Driver.FindElement(By.Id("next"));
            element.Click();
        }

        public void Back()
        {
           Driver.Navigate().Back();
        }

        public string TemplateName { 
            get
            {
                IWebElement element = Driver.FindElement(By.Id("templateName"));
                return element.Text;
            }
        }
    }
}
