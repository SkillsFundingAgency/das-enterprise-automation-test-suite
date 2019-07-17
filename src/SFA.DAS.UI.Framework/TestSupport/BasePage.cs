using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        private readonly IWebDriver _webDriver;
        private By pageHeading = By.CssSelector("h1");

        public BasePage(ScenarioContext context)
        {
            _webDriver = context.Get<IWebDriver>("webdriver");
        }

        protected abstract Boolean VerifyPage();

        protected String GetPageHeading()
        {
            return _webDriver.FindElement(pageHeading).Text;
        }
    }
}