using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public abstract class BasePage
    {
        protected IWebDriver webDriver;
        private By pageHeading = By.CssSelector("h1");

        public BasePage(IWebDriver _webDriver)
        {
            this.webDriver = _webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        protected abstract Boolean SelfVerify();

        protected String GetPageHeading()
        {
            return webDriver.FindElement(pageHeading).Text;
        }
    }
}