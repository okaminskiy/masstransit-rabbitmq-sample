using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Test.Customers.PageModels;

namespace Test.Customers.Steps
{
    [Binding, Scope(Tag = "templates")]
    class TemplatesSteps: StepsBase
    {
        private  TemplatesPage _page;
        //here are using regular expression

        //We can use many attribute in one TestMthedo to bind it to a feature

        [Given(@"^I am in (\w+)$")]
        public void OpenPage(string templateName)
        {
            _page = Container.Resolve<TemplatesPage>();
            Assert.AreEqual(templateName, _page.TemplateName);
        }

        [Then(@"^I am in (\w+)$")]
        public void AfterStepDone(string templateName)
        {
            Assert.AreEqual(templateName, _page.TemplateName);
            Assert.AreEqual(templateName, _page.TemplateName);
        }

        [When(@"I press next")]
        public void PressNext()
        {
            _page.ClickNext();
        }

        [When(@"I press back")]
        public void CheckStep()
        {
            _page.ClickBack();
        }
    }
}
