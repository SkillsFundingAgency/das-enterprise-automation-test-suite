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

        public void ClickElement(Func<IWebElement> element)
        {
            _retryHelper.RetryOnWebDriverException(element);
        }

        public void ClickElement(IWebElement element)
        {
            _retryHelper.RetryOnElementClickInterceptedException(element);
        }

        public void ClickElement(By locator)
        {
            _webDriverWaitHelper.WaitForElementToBeClickable(locator);
            ClickElement(_webDriver.FindElement(locator));
        }

        public void Click(By locator)
        {
            ClickElement(locator);
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, string text)
        {
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
            EnterText(_webDriver.FindElement(locator), text);
        }

        public void EnterSpace(By locator)
        {
            SendKeys(locator, Keys.Space);
        }

        public void SendKeys(By locator, string Key)
        {
            _webDriverWaitHelper.WaitForElementToBeDisplayed(locator);
            _webDriver.FindElement(locator).SendKeys(Key);
        }

        public void EnterText(By locator, int text)
        {
            EnterText(locator, text.ToString());
        }

        public void EnterText(IWebElement element, int value)
        {
            EnterText(element, value.ToString());
        }

        public void SelectByIndex(By @by, int index)
        {
            SelectByIndex(_webDriver.FindElement(by), index);
        }

        public void SelectFromDropDownByValue(By @by, string value)
        {
            SelectFromDropDownByValue(_webDriver.FindElement(by), value);
        }

        public void SelectFromDropDownByText(By @by, string text)
        {
            SelectFromDropDownByText(_webDriver.FindElement(by), text);
        }

        private void SelectByIndex(IWebElement element, int index)
        {
            SelectElement(element).SelectByIndex(index);
        }

        private void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement(element).SelectByValue(value);
        }

        private void SelectFromDropDownByText(IWebElement element, string text)
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
            ClickElementByText(locator, text);
        }

        private void ClickElementByText(By locator, String text)
        {
            IWebElement element()
            {
                IList<IWebElement> elements = _webDriver.FindElements(locator);

                for (int i = 0; i < elements.Count; i++)
                {
                    String str = elements.ElementAt(i).Text ?? elements.ElementAt(i).GetAttribute("innertext");
                    if (str.Contains(text))
                    {
                        return elements.ElementAt(i);
                    }
                }
                return null;
            }

           ClickElement(element);
        }

        public void ClickLinkByText(string text)
        {
            ClickElementByText(By.CssSelector("a"), text);
        }

        public void ClickButtonByText(string text)
        {
            ClickElementByText(By.CssSelector(".button"), text);
        }

        public void SelectRadioOptionByText(string text)
        {
            ClickElementByText(By.CssSelector("label.selection-button-radio"), text);
        }

        public void SelectCheckBoxByText(string text)
        {
            ClickElementByText(By.CssSelector("label.selection-button-checkbox"), text);
        }

        private SelectElement SelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}