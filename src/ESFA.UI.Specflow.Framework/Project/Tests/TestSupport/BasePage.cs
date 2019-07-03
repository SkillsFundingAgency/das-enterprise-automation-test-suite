using System;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public abstract class BasePage
    {
        protected IWebDriver webDriver;
        private By pageHeading = By.CssSelector("h1");

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            //PageFactory.InitElements(webDriver, this);
        }

        protected abstract Boolean SelfVerify();

        protected String GetPageHeading()
        {
            return webDriver.FindElement(pageHeading).Text;
        }
    }
}