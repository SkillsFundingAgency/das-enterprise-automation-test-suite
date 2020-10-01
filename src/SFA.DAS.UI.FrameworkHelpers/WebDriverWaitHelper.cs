using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class WebDriverWaitHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly JavaScriptHelper _javaScriptHelper;
        private readonly TimeOutConfig _timeOutConfig;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _implicitWait;
        private readonly OpenQA.Selenium.Support.UI.WebDriverWait _pagenavigationWait;

        public WebDriverWaitHelper(IWebDriver webDriver, JavaScriptHelper javaScriptHelper, TimeOutConfig timeOutConfig)
        {
            _webDriver = webDriver;
            _javaScriptHelper = javaScriptHelper;
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

        internal void WaitForElementToBeDisplayed(By locator) => _implicitWait.Until(ExpectedConditions.ElementIsVisible(locator));

        internal void WaitForElementToBeClickable(By locator) => _implicitWait.Until(ExpectedConditions.ElementToBeClickable(locator));

        internal void WaitForPageToLoad() => _pagenavigationWait.Until(driver => _javaScriptHelper.IsDocumentReady(driver));

        internal void TextToBePresentInElementLocated(By @by, string text) => _pagenavigationWait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));

        internal void TurnOffImplicitWaits() => _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        internal void TurnOnImplicitWaits() => _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_timeOutConfig.ImplicitWait);

        internal void WaitForUrlChange(string urlText) => _pagenavigationWait.Until(ExpectedConditions.UrlContains(urlText));

        private OpenQA.Selenium.Support.UI.WebDriverWait WebDriverWait(int timespan) => new OpenQA.Selenium.Support.UI.WebDriverWait(_webDriver, TimeSpan.FromSeconds(timespan));
    }
}