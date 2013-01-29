using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Test.Customers.PageModels
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver, string url)
        {
            Driver = driver;
            Driver.Navigate().GoToUrl(url);
        }
    }
}
