using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Polly;
using NUnit.Framework;
using System.Linq;
using System.Net;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RetryHelper
    {
        internal bool RetryOnException(Func<bool> func, Action beforeAction = null)
        {
            return Policy
                 .Handle<Exception>((x) => x.Message.Contains("verification failed"))
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
                 })
                 .Execute(() =>
                 {
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         beforeAction?.Invoke();
                         return func();
                     }
                 });
        }
        private static TimeSpan[] TimeOut => new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        };

    }


    public class PageInteractionHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWaitHelper _webDriverWaitHelper;
        private readonly RetryHelper _retryHelper;

        public PageInteractionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper)
        {
            _webDriver = webDriver;
            _webDriverWaitHelper = webDriverWaitHelper;
            _retryHelper = retryHelper;
        }

        public bool VerifyPage(By locator, string expected, Action beforeAction = null)
        {
            bool func()
            {
                var actual = GetText(locator);
                if (actual.Contains(expected))
                {
                    return true;
                }

                throw new Exception("Page verification failed:"
                    + "\n Expected: " + expected + " page"
                    + "\n Found: " + actual + " page");
            }
            
            return _retryHelper.RetryOnException(func, beforeAction);
        }

        public bool VerifyPage(string actual, string expected1, string expected2)
        {
            if (actual.Contains(expected1) || actual.Contains(expected2))
            {
                return true;
            }

            throw new Exception("Page verification failed: "
                + "\n Expected: " + expected1 + " or " + expected2 + " pages"
                + "\n Found: " + actual + " page");
        }

        public bool VerifyText(String actual, string expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public bool VerifyText(By locator, string expected)
        {
            var actual = GetText(locator);
            return VerifyText(actual, expected);
        }

        public bool VerifyValueAttributeOfAnElement(By locator, string expected)
        {
            var actual = _webDriver.FindElement(locator).GetAttribute("value");
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Value verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public string GetTextFromElementsGroup(By locator)
        {
            string text = null;
            IList<IWebElement> webElementGroup = _webDriver.FindElements(locator);

            foreach (IWebElement webElement in webElementGroup)
                text += GetText(webElement);

            return text;
        }
        public int GetCountOfElementsGroup(By locator)
        {
            return _webDriver.FindElements(locator).Count;
        }

        public bool IsElementPresent(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                _webDriver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                _webDriverWaitHelper.TurnOnImplicitWaits();
            }
        }

        public bool IsElementDisplayed(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                return _webDriver.FindElement(locator).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _webDriverWaitHelper.TurnOnImplicitWaits();
            }
        }

        public void FocusTheElement(By locator)
        {
            IWebElement webElement = _webDriver.FindElement(locator);
            new Actions(_webDriver).MoveToElement(webElement).Perform();
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
        }

        public void FocusTheElement(IWebElement element)
        {
            new Actions(_webDriver).MoveToElement(element).Perform();
        }

        public void UnFocusTheElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            new Actions(_webDriver).MoveToElement(webElement).Perform();
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
        }

        public void UnFocusTheElement(IWebElement element)
        {
            new Actions(_webDriver).MoveToElement(element).Perform();
        }

        public void TurnOffImplicitWaits()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public void SwitchToFrame(By locator)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        public string GetText(By locator) => GetText(_webDriver.FindElement(locator));

        public string GetText(IWebElement webElement) => webElement.Text;

        public string GetUrl() => _webDriver.Url;

        public IWebElement GetLink(By by, string linkText) => _webDriver.FindElements(by).ToList().First(x => x.GetAttribute("innerText") == linkText);

        public string GetRowData(By tableIdentifier, string rowIdentifier)
        {
            var rows = _webDriver.FindElement(tableIdentifier).FindElements(By.CssSelector("tr")).ToList();
            return rows.Where(x => x.FindElements(By.CssSelector("td")).Any(y => y?.Text == rowIdentifier)).SingleOrDefault()?.Text;
        }

    }
}