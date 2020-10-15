using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class PageInteractionHelper : WebElementInteractionHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWaitHelper _webDriverWaitHelper;
        private readonly RetryHelper _retryHelper;

        public PageInteractionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper) : base(webDriver)
        {
            _webDriver = webDriver;
            _webDriverWaitHelper = webDriverWaitHelper;
            _retryHelper = retryHelper;
        }

        public void InvokeAction(Action action, Action retryAction = null) => _retryHelper.RetryOnWebDriverException(action, retryAction);

        public void WaitForElementToChange(By locator, string text) => _webDriverWaitHelper.TextToBePresentInElementLocated(locator, text);

        public void WaitForElementToChange(By locator, string attribute, string value) => WaitForElementToChange(() => FindElement(locator), attribute, value);

        public void WaitForElementToChange(Func<IWebElement> element, string attribute, string value)
        {
            bool func(Func<IWebElement> webelement)
            {
                var actual = webelement().GetAttribute(attribute);
                if (actual.Contains(value))
                    return true;

                throw new WebDriverException($"Expected {attribute}=\"{value}\", Actual {attribute}=\"{actual}\"");
            }

            _retryHelper.RetryOnWebDriverException(() => func(element));
        }

        public void WaitforURLToChange(string urlText) => _webDriverWaitHelper.WaitForUrlChange(urlText);

        public void WaitForElementToBeClickable(By locator) => _webDriverWaitHelper.WaitForElementToBeClickable(locator);

        public void WaitForElementToBeDisplayed(By locator) => _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);

        public bool VerifyPage(Func<List<IWebElement>> elements, string expected)
        {
            bool func()
            {
                var actual = elements().Select(x => x.Text).ToList();
                if (actual.Any(x => x.Contains(expected)))
                    return true;

                throw new Exception("Page verification failed:"
                    + "\n Expected: " + expected + " page"
                    + "\n Found: " + string.Join(",", actual) + " page");
            }

            return VerifyPage(func);
        }

        public bool VerifyPage(Func<IWebElement> element, string expected, Action retryAction = null)
        {
            bool func()
            {
                var actual = GetText(element, retryAction);
                if (actual.Contains(expected))
                    return true;

                throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + actual + " page");
            }

            return VerifyPage(func);
        }

        public bool VerifyPage(By locator) => VerifyPage(Func(locator));

        public bool VerifyPage(By locator, string expected) => VerifyPage(() => FindElement(locator), expected);

        public bool VerifyPageAfterRefresh(By locator)
        {
            void beforeAction() => _webDriverWaitHelper.WaitForPageToLoad();

            return _retryHelper.RetryOnException(Func(locator), beforeAction, PageRefresh());
        }

        public Action PageRefresh() { return () => _webDriver.Navigate().Refresh(); }

        public void Verify(Func<bool> func, Action beforeAction) => _retryHelper.RetryOnException(func, beforeAction);

        private bool VerifyPage(Func<bool> func)
        {
            void beforeAction() => _webDriverWaitHelper.WaitForPageToLoad();

            return _retryHelper.RetryOnException(func, beforeAction);
        }

        public bool VerifyText(string actual, string expected1, string expected2)
        {
            if (actual.Contains(expected1) || actual.Contains(expected2))
                return true;

            throw new Exception("Text verification failed: "
                + "\n Expected: '" + expected1 + "' or '" + expected2 + "' text"
                + "\n Found: '" + actual + "' page");
        }

        public bool VerifyText(String actual, string expected)
        {
            if (actual.Contains(expected))
                return true;

            throw new Exception("Text verification failed: "
                + "\n Expected: " + expected
                + "\n Found: " + actual);
        }

        public bool VerifyText(By locator, string expected)
        {
            var actual = GetText(locator);
            return VerifyText(actual, expected);
        }

        public string GetTextFromElementsGroup(By locator)
        {
            string text = null;
            IList<IWebElement> webElementGroup = _webDriver.FindElements(locator);

            foreach (IWebElement webElement in webElementGroup)
                text += GetText(webElement);

            return text;
        }

        public IEnumerable<string> GetStringCollectionFromElementsGroup(By locator) => FindElements(locator).Select(e => e.Text);

        public bool IsElementPresent(By locator)
        {
            _webDriverWaitHelper.TurnOffImplicitWaits();
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
            _webDriverWaitHelper.TurnOffImplicitWaits();
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

        public void FocusTheElement(IWebElement element) => new Actions(_webDriver).MoveToElement(element).Perform();

        public void UnFocusTheElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            new Actions(_webDriver).MoveToElement(webElement).Perform();
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
        }

        public void UnFocusTheElement(IWebElement element) => new Actions(_webDriver).MoveToElement(element).Perform();

        public string GetText(By locator) => GetText(() => FindElement(locator));

        public string GetText(Func<IWebElement> element, Action retryAction = null) => _retryHelper.RetryOnWebDriverException<string>(() => element().Text, retryAction);

        public string GetTextFromPlaceholderAttributeOfAnElement(By by) => FindElement(by).GetAttribute(AttributeHelper.Placeholder);

        public string GetTextFromValueAttributeOfAnElement(By by) => FindElement(by).GetAttribute(AttributeHelper.Value);

        public string GetText(IWebElement webElement) => webElement.Text;

        public string GetUrl() => _webDriver.Url;

        public IWebElement GetLink(By by, string linkText) => GetLink(by, (x) => x == linkText);

        public IWebElement GetLinkContains(By by, string linkText) => GetLink(by, (x) => x.ContainsCompareCaseInsensitive(linkText));

        public string GetRowData(By tableIdentifier, By keyIdentifier, params string[] rowIdentifier) => FindElements(tableIdentifier).Where(x => x.FindElements(keyIdentifier).Any(y => rowIdentifier.Any(r => y?.Text == r))).SingleOrDefault()?.Text;

        public IWebElement FindElement(By locator) => _webDriver.FindElement(locator);

        public IWebElement FindElement(IWebElement element, By locator) => element.FindElement(locator);

        public List<IWebElement> FindElements(IWebElement element, By locator) => element.FindElements(locator).ToList();

        public List<IWebElement> FindElements(By locator) => _webDriver.FindElements(locator).ToList();

        public bool WaitUntilAnyElements(By locator) => _webDriverWaitHelper.WaitUntil(() => FindElements(locator).Count > 0);

        public IWebElement GetLinkByHref(string hrefContains) => FindElements(LinkCssSelector).First(x => x.GetAttribute("href").ContainsCompareCaseInsensitive(hrefContains));

        public IWebElement GetLink(By by, Func<string, bool> func) => FindElements(by).First(x => func(x.GetAttribute(AttributeHelper.InnerText)));

        public List<IWebElement> GetLinks(By by, string linkText) => FindElements(by).Where(x => x.GetAttribute(AttributeHelper.InnerText) == linkText).ToList();

        public List<IWebElement> GetLinks(string linkText) => FindElements(LinkCssSelector).Where(x => x.GetAttribute(AttributeHelper.InnerText).ContainsCompareCaseInsensitive(linkText)).ToList();

        public List<string> GetAvailableOptions(By @by) => SelectElement(FindElement(by)).Options.Where(t => !string.IsNullOrEmpty(t.Text)).Select(x => x.Text).ToList();

        private Func<bool> Func(By locator)
        {
            return () =>
            {
                if (FindElements(locator).Count > 0)
                    return true;
                throw new Exception($"Page verification failed:{locator} is not found");
            };
        }

        public bool GetElementSelectedStatus(By locator) => FindElement(locator).Selected;
    }
}
