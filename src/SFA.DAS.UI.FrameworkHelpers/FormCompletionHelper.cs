using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class FormCompletionHelper : WebElementInteractionHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWaitHelper _webDriverWaitHelper;
        private readonly RetryHelper _retryHelper;

        public FormCompletionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper) : base(webDriver)
        {
            _webDriver = webDriver;
            _webDriverWaitHelper = webDriverWaitHelper;
            _retryHelper = retryHelper;
        }

        public void SelectRadioButton(IWebElement element) => ClickElement(element);

        public void RetryClickOnException(Func<IWebElement> element) => _retryHelper.RetryClickOnException(element);

        public void ClickElement(Func<IWebElement> element, Action retryAction = null) => _retryHelper.RetryClickOnWebDriverException(element, retryAction);

        public void ClickElement(IWebElement element) => _retryHelper.RetryOnElementClickInterceptedException(element, true);

        //links are Intercepted by Help menu.
        public void ClickInterceptedElement(IWebElement element) => _retryHelper.RetryOnElementClickInterceptedException(element, false);

        public void ClickElement(By locator)
        {
            _webDriverWaitHelper.WaitForElementToBeClickable(locator);
            ClickElement(_webDriver.FindElement(locator));
        }

        public void Click(By locator) => ClickElement(locator);

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterGently(IWebElement element, string text)
        {
            element.Clear();
            foreach (var letter in text.ToCharArray())
            {
                element.SendKeys(letter.ToString());
            }
        }

        public void EnterGently(By locator, string text)
        {
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
            EnterGently(_webDriver.FindElement(locator), text);
        }

        public void EnterText(By locator, string text)
        {
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
            EnterText(_webDriver.FindElement(locator), text);
        }

        public void EnterSpace(By locator) => SendKeys(locator, Keys.Space);

        public void SendKeys(By locator, string Key)
        {
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
            _webDriver.FindElement(locator).SendKeys(Key);
        }

        public void EnterText(By locator, int text) => EnterText(locator, text.ToString());

        public void EnterText(IWebElement element, int value) => EnterText(element, value.ToString());

        public void SelectByIndex(By @by, int index) => SelectByIndex(_webDriver.FindElement(by), index);

        public void SelectFromDropDownByValue(By @by, string value) => SelectFromDropDownByValue(_webDriver.FindElement(by), value);

        public void SelectFromDropDownByText(By @by, string text) => SelectFromDropDownByText(_webDriver.FindElement(by), text);

        private void SelectByIndex(IWebElement element, int index) => SelectElement(element).SelectByIndex(index);

        private void SelectFromDropDownByValue(IWebElement element, string value) => SelectElement(element).SelectByValue(value);

        private void SelectFromDropDownByText(IWebElement element, string text) => SelectElement(element).SelectByText(text);

        public void SelectCheckbox(IWebElement element)
        {
            if(!element.Selected)
                element.Click();
        }

        public void UnSelectCheckbox(IWebElement element)
        {
            if (element.Selected)
                element.Click();
        }

        public void UnSelectCheckbox(By locator)
        {
            IWebElement element = _webDriver.FindElement(locator);
            UnSelectCheckbox(element);
        }

        public void SelectCheckbox(By locator)
        {
            IWebElement element = _webDriver.FindElement(locator);
            SelectCheckbox(element);
        }

        public void SelectRadioOptionByForAttribute(By locator, string forAttribute)
        {
            IList<IWebElement> radios = _webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }
        
        public void SelectRadioOptionByText(By locator, string text) => ClickElementByText(locator, text);

        public void SelectCheckboxByText(By locator, string text) => ClickElementByText(locator, text);

        public void EnterTextByLabel(By labellocator, string labeltext, string text) => EnterText(GetElementByText(labellocator, labeltext).FindElement(InputCssSelector), text);

        private void ClickElementByText(By locator, string text) => ClickElement(() => GetElementByText(locator, text));

        public void ClickLinkByText(By locator, string text) => ClickElementByText(locator, text);

        public void ClickLinkByText(string text) => ClickElementByText(LinkCssSelector, text);

        public void ClickButtonByText(params string[] buttons)
        {
            string text = buttons.First(x => GetElementByText(ButtonCssSelector, x) != null);

            ClickElementByText(ButtonCssSelector, text);
        }

        public void ClickButtonByText(string text) => ClickElementByText(ButtonCssSelector, text);

        public void SelectRadioOptionByText(string text) => ClickElementByText(RadioButtonCssSelector, text);

        public void SelectCheckBoxByText(string text) => ClickElementByText(CheckBoxCssSelector, text);
    }
}