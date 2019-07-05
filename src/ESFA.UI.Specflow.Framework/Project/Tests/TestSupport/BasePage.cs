using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public abstract class BasePage
    {
        private readonly IWebDriver _webDriver;
        private By pageHeading = By.CssSelector("h1");

        public BasePage(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext.Get<IWebDriver>();
        }

        protected abstract Boolean SelfVerify();

        protected String GetPageHeading()
        {
            return _webDriver.FindElement(pageHeading).Text;
        }
    }
}