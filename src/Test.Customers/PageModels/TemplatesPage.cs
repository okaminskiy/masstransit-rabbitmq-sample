using System;
using OpenQA.Selenium;

namespace Test.Customers.PageModels
{
    public class TemplatesPage: BasePage
    {
        //TODO: oleg - push it to app.config
        private const string Url = "http://localhost:3333/Customers/steps";

        public TemplatesPage(IWebDriver driver) : base(driver, Url)
        {}

        public void ClickNext()
        {
            IWebElement element = Driver.FindElement(By.Id("next"));
            element.Click();
        }

        public void ClickBack()
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
