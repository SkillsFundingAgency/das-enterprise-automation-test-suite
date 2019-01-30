using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class PageInteractionHelper
    {
        protected IWebDriver webDriver;
        private const int implicitWaitTimeInSeconds = 10;

        public PageInteractionHelper(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public Boolean VerifyPageHeading(String actual, String expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
        }

        public Boolean VerifyPageHeading(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
        }

        public Boolean VerifyPageHeading(String actual, String expected1, String expected2)
        {
            if (actual.Contains(expected1) || actual.Contains(expected2))
            {
                return true;
            }

            throw new Exception("Page verification failed: "
                + "\n Expected: " + expected1 + " or " + expected2 + " pages"
                + "\n Found: " + actual + " page");
        }

        public Boolean VerifyText(String actual, String expected)
        {
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public Boolean VerifyText(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).Text;
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public Boolean VerifyValueAttributeOfAnElement(By locator, String expected)
        {
            String actual = webDriver.FindElement(locator).GetAttribute("value");
            if (actual.Contains(expected))
            {
                return true;
            }

            throw new Exception("Value verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public void WaitForPageToLoad(int implicitWaitTime = implicitWaitTimeInSeconds)
        {
            var waitForDocumentReady = new WebDriverWait(webDriver, TimeSpan.FromSeconds(implicitWaitTime));
            waitForDocumentReady.Until((wdriver) => (webDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForElementToBePresent(By locator)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(implicitWaitTimeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeDisplayed(By locator, int timeInSeconds = implicitWaitTimeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement element = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public Boolean IsElementPresent(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                webDriver.FindElement(locator);
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

        public Boolean IsElementDisplayed(By locator)
        {
            TurnOffImplicitWaits();
            try
            {
                return webDriver.FindElement(locator).Displayed;
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
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void FocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public void UnFocusTheElement(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            new Actions(webDriver).MoveToElement(webElement).Perform();
            WaitForElementToBeDisplayed(locator);
        }

        public void UnFocusTheElement(IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Perform();
        }

        public void TurnOffImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public void TurnOnImplicitWaits()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTimeInSeconds);
        }

        public String GetText(By locator)
        {
            IWebElement webElement = webDriver.FindElement(locator);
            return webElement.Text;
        }
    }
}