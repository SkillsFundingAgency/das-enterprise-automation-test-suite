using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class FormCompletionHelper 
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWaitHelper _webDriverWaitHelper;
        private readonly RetryHelper _retryHelper;

        public FormCompletionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, RetryHelper retryHelper)
        {
            _webDriver = webDriver;
            _webDriverWaitHelper = webDriverWaitHelper;
            _retryHelper = retryHelper;
        }

        public void SelectRadioButton(IWebElement element)
        {
            ClickElement(element);
        }

        public void SelectRadioButton(By locator)
        {
            SelectRadioButton(_webDriver.FindElement(locator));
        }

        public void ClickElement(IWebElement element, bool useAction = false)
        {
            _retryHelper.RetryOnElementClickInterceptedException(element, useAction);
        }

        public void ClickElement(By locator, bool useAction = false)
        {
            _webDriverWaitHelper.WaitForElementToBeClickable(locator);
            ClickElement(_webDriver.FindElement(locator), useAction);
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, string text)
        {
            EnterText(_webDriver.FindElement(locator), text);
        }

        public void EnterText(By locator, int text)
        {
            EnterText(locator, text.ToString());
        }

        public void EnterText(IWebElement element, int value)
        {
            EnterText(element, value.ToString());
        }

        public void SelectFromDropDownByValue(By @by, string value)
        {
            SelectFromDropDownByValue(_webDriver.FindElement(by), value);
        }

        public void SelectFromDropDownByText(By @by, string text)
        {
            SelectFromDropDownByText(_webDriver.FindElement(by), text);
        }

        public void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement(element).SelectByValue(value);
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement(element).SelectByText(text);
        }

        public void SelectCheckBox(IWebElement element)
        {
            if(element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public void SelectRadioOptionByForAttribute(By locator, string forAttribute)
        {
            IList<IWebElement> radios = _webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }

        public void SelectRadioOptionByText(By locator, String text)
        {
            IList<IWebElement> radios = _webDriver.FindElements(locator);

            for (int i = 0; i < radios.Count; i++)
            {
                String str = radios.ElementAt(i).Text;
                if (str.Equals(text))
                {
                    radios.ElementAt(i).Click();
                    return;
                }
            }
        }

        private SelectElement SelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}