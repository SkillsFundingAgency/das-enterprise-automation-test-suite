using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly TimeOutConfig _timeOutConfig;

        public WebDriverWaitHelper(IWebDriver webDriver, TimeOutConfig timeOutConfig)
        {
            _webDriver = webDriver;
            _timeOutConfig = timeOutConfig;
        }

        public void WaitForElementToBePresent(By locator)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public void WaitForPageToLoad()
        {
            var waitForDocumentReady = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(_timeOutConfig.PageNavigation));
            waitForDocumentReady.Until(driver => ((IJavaScriptExecutor)_webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void TurnOnImplicitWaits()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait);
        }

    }
}