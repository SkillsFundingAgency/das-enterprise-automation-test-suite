using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.TestSupport
{
    public abstract class BasePage
    {
        private readonly IWebDriver _webDriver;
        private By pageHeading = By.CssSelector("h1");

        public BasePage(ScenarioContext context)
        {
            _webDriver = context.Get<IWebDriver>("webdriver");
        }

        protected abstract Boolean SelfVerify();

        protected String GetPageHeading()
        {
            return _webDriver.FindElement(pageHeading).Text;
        }
    }
}