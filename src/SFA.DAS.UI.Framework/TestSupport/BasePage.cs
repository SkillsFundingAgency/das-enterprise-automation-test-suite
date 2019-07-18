using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        private readonly IWebDriver _webDriver;
        private readonly By pageHeading = By.CssSelector("h1");

        public BasePage(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
        }

        protected abstract bool VerifyPage();

        protected string GetPageHeading()
        {
            return _webDriver.FindElement(pageHeading).Text;
        }
    }
}