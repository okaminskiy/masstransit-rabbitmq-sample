using OpenQA.Selenium;

namespace Test.Customers.PageModels
{
    public class TemplatesPage: BasePage
    {
        private const string Url = "http://localhost:21634/steps";

        public TemplatesPage(IWebDriver driver) : base(driver, Url)
        {}

        public void ClickNext()
        {
            IWebElement element = Driver.FindElement(By.Id("next"));
            element.Click();
        }

        public void ClickBack()
        {
            IWebElement element = Driver.FindElement(By.Id("back"));
            element.Click();
        }

        public string TemplateName { 
            get
            {
                IWebElement element = Driver.FindElement(By.Id("templateName"));
                return element.GetAttribute("value");
            }
        }
    }
}
