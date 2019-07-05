using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ESFA.UI.Specflow.Framework.Helpers
{
    public class PageInteractionHelper
    {
        protected IWebDriver WebDriver;
        private const int ImplicitWaitTimeInSeconds = 10;

        public PageInteractionHelper(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public bool VerifyPageHeading(string actual, string expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
        }

        public bool VerifyPageHeading(By locator, string expected)
        {
            var actual = WebDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
        }

        public bool VerifyPageHeading(string actual, string expected1, string expected2)
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
            var actual = WebDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public Boolean VerifyValueAttributeOfAnElement(By locator, string expected)
        {
            var actual = WebDriver.FindElement(locator).GetAttribute("value");
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
            var waitForDocumentReady = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(implicitWaitTime));
            waitForDocumentReady.Until(driver => ((IJavaScriptExecutor) WebDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForElementToBePresent(By locator)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator, int timeInSeconds = ImplicitWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            var webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool IsElementPresent(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                WebDriver.FindElement(locator);
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
                return WebDriver.FindElement(locator).Displayed;
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
            IWebElement webElement = WebDriver.FindElement(locator);
            new Actions(WebDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void FocusTheElement(IWebElement element)
        {
            new Actions(WebDriver).MoveToElement(element).Perform();
        }

        public void UnFocusTheElement(By locator)
        {
            var webElement = WebDriver.FindElement(locator);
            new Actions(WebDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void UnFocusTheElement(IWebElement element)
        {
            new Actions(WebDriver).MoveToElement(element).Perform();
        }

        public void TurnOffImplicitWaits()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public void TurnOnImplicitWaits()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeInSeconds);
        }

        public string GetText(By locator)
        {
            var webElement = WebDriver.FindElement(locator);
            return webElement.Text;
        }
    }
}