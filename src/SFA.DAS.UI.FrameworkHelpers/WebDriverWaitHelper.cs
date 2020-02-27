using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly TimeOutConfig _timeOutConfig;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _implicitWait;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _pagenavigationWait;

        public WebDriverWaitHelper(IWebDriver webDriver, TimeOutConfig timeOutConfig)
        {
            _webDriver = webDriver;
            _timeOutConfig = timeOutConfig;
            _implicitWait = WebDriverWait(timeOutConfig.ImplicitWait);
            _pagenavigationWait = WebDriverWait(timeOutConfig.PageNavigation);
        }

        internal bool WaitUntil(Func<bool> condition)
        {
            var implicitWait = WebDriverWait(_timeOutConfig.ImplicitWait);

            implicitWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));

            bool result = false;

            implicitWait.Until(driver => 
            {
                result = condition();
                return result; 
            });

            return result;
        }

        internal void WaitForElementToBePresent(By locator) => _implicitWait.Until(ExpectedConditions.ElementExists(locator));

        internal void WaitForElementToBeDisplayed(By locator) => _implicitWait.Until(ExpectedConditions.ElementIsVisible(locator));

        internal void WaitForElementToBeClickable(By locator) => _implicitWait.Until(ExpectedConditions.ElementToBeClickable(locator));

        internal void WaitForPageToLoad() => _pagenavigationWait.Until(driver => IsDocumentReady(driver));

        internal void WaitforURLToChange(string url) => _pagenavigationWait.Until(ExpectedConditions.UrlContains(url));

        internal void TextToBePresentInElementLocated(By @by, string text) => _pagenavigationWait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));

        internal void TurnOffImplicitWaits() => _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        internal void TurnOnImplicitWaits() => _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait);

        private bool IsDocumentReady(IWebDriver driver) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");

        private OpenQA.Selenium.Support.UI.WebDriverWait WebDriverWait(int timespan) => new OpenQA.Selenium.Support.UI.WebDriverWait(_webDriver, TimeSpan.FromSeconds(timespan));
    }
}