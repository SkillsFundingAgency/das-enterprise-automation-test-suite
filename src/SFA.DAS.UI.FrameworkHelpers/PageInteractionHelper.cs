using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public static class ExceptionMessageHelper
{
    public static string GetExceptionMessage(string x, string expected, string actual) => $"{x} verification failed:{Environment.NewLine}Expected: {expected} page {Environment.NewLine}Found: {actual} page";
}

public class PageInteractionHelper(IWebDriver webDriver, ObjectContext objectContext, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper) : WebElementInteractionHelper(webDriver)
{
    public void RefreshPage()
    {
        webDriver.Navigate().Refresh();

        SetDebugInformation($"Refreshed page...");
    }

    public string GetUrl() => webDriver.Url;

    public void InvokeAction(Action action, Action retryAction = null) => retryHelper.RetryOnWebDriverException(action, retryAction);

    public T InvokeAction<T>(Func<T> func, Action retryAction = null) => retryHelper.RetryOnWebDriverException(func, retryAction);

    public void WaitForElementToChange(By locator, string text) => webDriverWaitHelper.TextToBePresentInElementLocated(locator, text);

    public void WaitForElementToChange(By locator, string attribute, string value)
    {
        WaitForElementToChange(() => FindElement(locator), attribute, value);

        SetDebugInformation($"waited for '{locator}' : attribute : '{attribute}' to change to : '{value}'");
    }

    public void WaitforURLToChange(string urlText) => webDriverWaitHelper.WaitForUrlChange(urlText);

    public void WaitForElementToBeClickable(By locator) => webDriverWaitHelper.WaitForElementToBeClickable(locator);

    public void WaitForElementToBeDisplayed(By locator) => webDriverWaitHelper.WaitForElementToBeDisplayed(locator);

    public bool VerifyPage(Func<List<IWebElement>> elements, string expected)
    {
        bool func()
        {
            var actual = elements().Select(x => x.Text).ToList();

            if (actual.Any(x => x.Contains(expected)))
            {
                SetDebugInformation($"Verified page - '{expected}'"); return true;
            }

            throw new Exception("Page verification failed:"
                + "\n Expected: " + expected + " page"
                + "\n Found: " + string.Join(",", actual) + " page");
        }

        return VerifyPage(func);
    }

    public bool VerifyPage(Func<IWebElement> element, List<string> expected, Action retryAction = null)
    {
        bool func()
        {
            var actual = GetText(element, retryAction);

            if (expected.Any(x => actual.Contains(x)))
            {
                SetDebugInformation($"Verified page - '{string.Join("/", expected)}'"); return true;
            }

            throw new Exception("Page verification failed:"
            + "\n Expected: " + string.Join(" OR ", expected) + " page"
            + "\n Found: " + actual + " page");
        }

        return VerifyPage(func, retryAction);
    }

    public bool VerifyPage(Func<IWebElement> element, string expected, Action retryAction = null)
    {
        bool func()
        {
            var actual = GetText(element, retryAction);

            if (actual.Contains(expected))
            {
                SetDebugInformation($"Verified page - '{expected}'"); return true;
            }

            throw new Exception(ExceptionMessageHelper.GetExceptionMessage("Page", expected, actual));
        }

        return VerifyPage(func, retryAction);
    }

    public bool VerifyPage(By locator, Action retryAction = null) => VerifyPage(Func(locator), retryAction);

    public bool VerifyPage(By locator, string expected, Action retryAction = null) => VerifyPage(() => FindElement(locator), expected, retryAction);

    public bool VerifyPageAfterRefresh(By locator) => retryHelper.RetryOnException(Func(locator), WaitForPageToLoad, RefreshPage);

    public bool Verify(Func<bool> func, Action beforeAction) => retryHelper.RetryOnException(func, beforeAction);

    private bool VerifyPage(Func<bool> func, Action retryAction = null) => retryHelper.RetryOnException(func, WaitForPageToLoad, retryAction);

    public bool VerifyText(string actual, string expected1, string expected2)
    {
        if (actual.Contains(expected1) || actual.Contains(expected2))
        {
            SetDebugInformation($"Verifed text - '{expected1}/{expected2}'"); return true;
        }

        throw new Exception("Text verification failed: "
            + "\n Expected: '" + expected1 + "' or '" + expected2 + "' text"
            + "\n Found: '" + actual + "' page");
    }

    public bool VerifyText(string actual, string expected)
    {
        if (actual.Contains(expected))
            SetDebugInformation($"Verifed text - '{expected}'"); return true;

        throw new Exception("Text verification failed: "
            + "\n Expected: " + expected
            + "\n Found: " + actual);
    }

    public bool VerifyText(By locator, string expected)
    {
        var actual = GetText(locator);
        return VerifyText(actual, expected);
    }

    public (bool, string) CheckText(By locator, string expected)
    {
        var actual = GetText(locator);
        return (actual.Contains(expected), actual);
    }

    public string GetTextFromElementsGroup(By locator)
    {
        string text = null;
        IList<IWebElement> webElementGroup = webDriver.FindElements(locator);

        foreach (IWebElement webElement in webElementGroup)
            text += GetText(webElement);

        return text;
    }

    public IEnumerable<string> GetStringCollectionFromElementsGroup(By locator) => FindElements(locator).Select(e => e.Text);

    public void VerifyRadioOptionSelectedByText(string text, bool isSelected)
    {
        retryHelper.RetryOnWebDriverException(() =>
        {
            var selected = GetElementByAttribute(RadioButtonInputCssSelector, AttributeHelper.Value, text)?.Selected ?? false;

            if (isSelected != selected) throw new WebDriverException($"Radio option '{text}' selection verification failed: Expected: {isSelected} Found: {selected}");
        });
    }

    public bool IsElementPresent(By locator)
    {
        webDriverWaitHelper.TurnOffImplicitWaits();
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
            webDriverWaitHelper.TurnOnImplicitWaits();
        }
    }

    public bool IsElementDisplayedAfterPageLoad(By locator)
    {
        WaitForPageToLoad();

        return IsElementDisplayed(locator);
    }

    public bool IsElementDisplayed(By locator) => WithoutImplicitWaits(() =>
    {
        static string text(bool a) => a ? "displayed" : "not displayed";

        var x = webDriver.FindElement(locator).Displayed;

        SetDebugInformation($"Verified {locator} is {text(x)}");

        return x;
    });

    public T WithoutImplicitWaits<T>(Func<T> func)
    {
        webDriverWaitHelper.TurnOffImplicitWaits();
        try
        {
            return func();
        }
        catch (Exception)
        {
            return default;
        }
        finally
        {
            webDriverWaitHelper.TurnOnImplicitWaits();
        }
    }

    public void FocusTheElement(By locator)
    {
        IWebElement webElement = webDriver.FindElement(locator);
        new Actions(webDriver).MoveToElement(webElement).Perform();
        webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
    }

    public void FocusTheElement(IWebElement element) => new Actions(webDriver).MoveToElement(element).Perform();

    public void UnFocusTheElement(By locator)
    {
        var webElement = webDriver.FindElement(locator);
        new Actions(webDriver).MoveToElement(webElement).Perform();
        webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
    }

    public void UnFocusTheElement(IWebElement element) => new Actions(webDriver).MoveToElement(element).Perform();

    public string GetText(By locator) => GetText(() => FindElement(locator));

    public string GetText(Func<IWebElement> element, Action retryAction = null) => retryHelper.RetryOnWebDriverException<string>(() => element().Text, retryAction);

    public string GetTextFromPlaceholderAttributeOfAnElement(By by) => FindElement(by).GetAttribute(AttributeHelper.Placeholder);

    public string GetTextFromValueAttributeOfAnElement(By by) => FindElement(by).GetAttribute(AttributeHelper.Value);

    public int GetDataCountOfAnElement(By by) => int.Parse(FindElement(by).GetAttribute(AttributeHelper.DataCount));

    public static string GetText(IWebElement webElement) => webElement.Text;

    public IWebElement GetLink(By by, string linkText) => GetLink(by, (x) => x == linkText);

    public IWebElement GetLinkContains(By by, string linkText) => GetLink(by, (x) => x.ContainsCompareCaseInsensitive(linkText));

    public string GetRowData(By tableIdentifier, By keyIdentifier, params string[] rowIdentifier) => FindElements(tableIdentifier).Where(x => x.FindElements(keyIdentifier).Any(y => rowIdentifier.Any(r => y?.Text == r))).SingleOrDefault()?.Text;

    public IWebElement FindElement(By locator) => webDriver.FindElement(locator);

    public List<IWebElement> FindElements(IWebElement element, By locator, bool withoutImplicitWaits = false) =>
        withoutImplicitWaits ? WithoutImplicitWaits(() => element.FindElements(locator).ToList()) : [.. element.FindElements(locator)];

    public List<IWebElement> FindElements(By locator) => webDriver.FindElements(locator).ToList();

    public bool WaitUntilAnyElements(By locator)
    {
        var result = webDriverWaitHelper.WaitUntil(() => FindElements(locator).Count > 0);

        SetDebugInformation($"wait until elements : '{locator}' count > 0, result '{result}'");

        return result;
    }

    public IWebElement GetLinkByHref(string hrefContains) => FindElements(LinkCssSelector).First(x => x.GetAttribute("href").ContainsCompareCaseInsensitive(hrefContains));

    public IWebElement GetLink(By by, Func<string, bool> func) => FindElements(by).First(x => func(x.GetAttribute(AttributeHelper.InnerText)));

    public List<IWebElement> GetLinks(By by, string linkText) => FindElements(by).Where(x => x.GetAttribute(AttributeHelper.InnerText) == linkText).ToList();

    public List<IWebElement> GetLinks(string linkText) => FindElements(LinkCssSelector).Where(x => x.GetAttribute(AttributeHelper.InnerText).ContainsCompareCaseInsensitive(linkText)).ToList();

    public List<string> GetAvailableSelectOptions(By @by) => SelectElement(FindElement(by)).Options.Where(t => !string.IsNullOrEmpty(t.Text)).Select(x => x.Text).ToList();

    public List<string> GetAvailableRadioOptions() => FindElements(RadioButtonLabelCssSelector).Select(p => p.GetAttribute(AttributeHelper.InnerText)).ToList();

    private void SetDebugInformation(string x) => objectContext.SetDebugInformation(x);

    private Func<bool> Func(By locator)
    {
        return () =>
        {
            if (FindElements(locator).Count > 0)
            {
                SetDebugInformation($"Verifed locator - '{locator}'"); return true;
            }
            throw new Exception($"Page verification failed:{locator} is not found");
        };
    }

    public bool GetElementSelectedStatus(By locator) => FindElement(locator).Selected;

    private void WaitForPageToLoad() => webDriverWaitHelper.WaitForPageToLoad();

    private void WaitForElementToChange(Func<IWebElement> element, string attribute, string value)
    {
        bool func(Func<IWebElement> webelement)
        {
            var actual = webelement().GetAttribute(attribute);

            if (actual.Contains(value)) return true;

            throw new WebDriverException($"Expected {attribute}=\"{value}\", Actual {attribute}=\"{actual}\"");
        }

        retryHelper.RetryOnWebDriverException(() => func(element));
    }
}