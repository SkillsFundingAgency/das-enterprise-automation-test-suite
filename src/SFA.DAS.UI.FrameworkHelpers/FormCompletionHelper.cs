using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public class FormCompletionHelper(IWebDriver webDriver, ObjectContext objectContext, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper) : WebElementInteractionHelper(webDriver)
{
    public void RetryClickOnException(Func<IWebElement> element) => retryHelper.RetryClickOnException(element);

    public void ClickElement(Func<IWebElement> element, Action retryAction = null) => retryHelper.RetryClickOnWebDriverException(element, retryAction);

    public void ClickElement(IWebElement element, bool useAction = true) => retryHelper.RetryOnElementClickInterceptedException(element, useAction);

    public void ClickElement(By locator)
    {
        webDriverWaitHelper.WaitForElementToBeClickable(locator);

        ClickElement(webDriver.FindElement(locator));

        SetDebugInformation($"Clicked '{locator}'");
    }

    public void Click(By locator) => ClickElement(locator);

    public void EnterText(IWebElement element, string text)
    {
        element.Clear();

        element.SendKeys(text);

        SetDebugInformation($"Entered '{text}'");
    }

    public void EnterText(By locator, string text)
    {
        webDriverWaitHelper.WaitForElementToBeDisplayed(locator);

        EnterText(webDriver.FindElement(locator), text);
    }

    public List<string> GetAllDropDownOptions(By bySelect) => GetAllDropDown(bySelect, (x) => x.Text); 

    public List<string> GetAllDropDownValue(By bySelect) => GetAllDropDown(bySelect, (x) => x.GetAttribute("value"));

    private List<string> GetAllDropDown(By bySelect, Func<IWebElement, string> func) => SelectElement(bySelect).Options.Where(x => !string.IsNullOrEmpty(x.GetAttribute("value"))).Select(x => func(x)).ToList();

    public string GetSelectedOption(By bySelect) => SelectElement(bySelect).SelectedOption.Text;

    public void SendKeys(By locator, string Key)
    {
        webDriverWaitHelper.WaitForElementToBeDisplayed(locator);

        webDriver.FindElement(locator).SendKeys(Key);

        SetDebugInformation($"Entered '{Key}'");
    }

    public void EnterText(By locator, int text) => EnterText(locator, text.ToString());

    public void EnterText(IWebElement element, int value) => EnterText(element, value.ToString());

    public void SelectFromDropDownByValue(By @by, string value) => SelectFromDropDownByValue(webDriver.FindElement(by), value);

    public void SelectFromDropDownByText(By @by, string text) => SelectFromDropDownByText(webDriver.FindElement(by), text);

    private void SelectFromDropDownByValue(IWebElement element, string value) { SelectElement(element).SelectByValue(value); SetDebugInformation($"Selected '{value}'"); }

    private void SelectFromDropDownByText(IWebElement element, string text) { SelectElement(element).SelectByText(text); SetDebugInformation($"Selected '{text}'"); }

    public void SelectCheckbox(IWebElement element)
    {
        if (!element.Selected) element.Click();
    }

    public void UnSelectCheckbox(IWebElement element)
    {
        if (element.Selected) element.Click();
    }

    public void UnSelectCheckbox(By locator)
    {
        UnSelectCheckbox(webDriver.FindElement(locator));

        SetDebugInformation($"Unchecked '{locator}'");
    }

    public void SelectCheckbox(By locator)
    {
        SelectCheckbox(webDriver.FindElement(locator));

        SetDebugInformation($"Checked '{locator}'");
    }

    public void SelectCheckBoxByText(By locator, string text) => ClickElementByText(locator, text);

    public void SelectCheckBoxByText(string text) => ClickElementByText(CheckBoxCssSelector, text);

    public void SelectRadioOptionByForAttribute(By locator, string forAttribute)
    {
        IList<IWebElement> radios = webDriver.FindElements(locator);

        var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

        if (radioToSelect != null) { ClickElement(radioToSelect); SetDebugInformation($"Clicked 'for='{forAttribute}''"); } 
    }

    public void SelectRadioOptionByText(By locator, string text) => ClickElementByText(locator, text);

    public void SelectRadioOptionByText(string text) => ClickElementByText(RadioButtonLabelCssSelector, text);

    public void SelectRadioOptionByLocator(By locator) => ClickElement(webDriver.FindElement(locator));

    public void EnterTextByLabel(By labellocator, string labeltext, string text) => EnterText(GetElementByText(labellocator, labeltext).FindElement(InputCssSelector), text);

    private void ClickElementByText(By locator, string text) { ClickElement(() => GetElementByText(locator, text)); SetDebugInformation($"Clicked '{text}'"); }

    public void ClickLinkByText(By locator, string text) => ClickElementByText(locator, text);

    public void ClickLinkByText(string text) => ClickElementByText(LinkCssSelector, text);

    public void ClickButtonByText(params string[] buttons)
    {
        string text = buttons.First(x => GetElementByText(ButtonCssSelector, x) != null);

        ClickElementByText(ButtonCssSelector, text);
    }

    public void ClickButtonByText(string text) => ClickElementByText(ButtonCssSelector, text);

    public void ClickButtonByText(By locator, string text) => ClickElementByText(locator, text);

    public void SetDebugInformation(string x) => objectContext.SetDebugInformation(x);
}