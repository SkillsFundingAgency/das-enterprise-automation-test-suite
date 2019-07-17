using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
        public FormCompletionHelper(IWebDriver webDriver) :base(webDriver)
        {

        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void ClickElement(By locator)
        {
            ClickElement(WebDriver.FindElement(locator));
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, string text)
        {
            EnterText(WebDriver.FindElement(locator), text);
        }

        public void EnterText(IWebElement element, int value)
        {
            EnterText(element, value.ToString());
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
            IList<IWebElement> radios = WebDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }

        private SelectElement SelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}