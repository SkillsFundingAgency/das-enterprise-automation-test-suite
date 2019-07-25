using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class PageInteractionHelper
    {
        private readonly IWebDriver _webDriver;
        private const int ImplicitWaitTimeInSeconds = 10;

        public PageInteractionHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool VerifyPage(string actual, string expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
        }

        public bool VerifyPage(By locator, string expected)
        {
            var actual = _webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
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
            var actual = _webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
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

        public void WaitForPageToLoad(int implicitWaitTime = ImplicitWaitTimeInSeconds)
        {
            var waitForDocumentReady = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(implicitWaitTime));
            waitForDocumentReady.Until(driver => ((IJavaScriptExecutor) _webDriver).ExecuteScript("return document.readyState").Equals("complete"));
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

        public void WaitForElementToBePresent(By locator)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator, int timeInSeconds = ImplicitWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
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
                TurnOnImplicitWaits();
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
                TurnOnImplicitWaits();
            }
        }

        public void FocusTheElement(By locator)
        {
            IWebElement webElement = _webDriver.FindElement(locator);
            new Actions(_webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void FocusTheElement(IWebElement element)
        {
            new Actions(_webDriver).MoveToElement(element).Perform();
        }

        public void UnFocusTheElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            new Actions(_webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void UnFocusTheElement(IWebElement element)
        {
            new Actions(_webDriver).MoveToElement(element).Perform();
        }

        public void TurnOffImplicitWaits()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public void TurnOnImplicitWaits()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds);
        }

        public void SwitchToFrame(By locator)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }

        public string GetText(By locator) => GetText(_webDriver.FindElement(locator));

        public string GetText(IWebElement webElement) => webElement.Text;
    }
}