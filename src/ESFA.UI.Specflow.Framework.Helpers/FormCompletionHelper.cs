using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.UI.Specflow.Framework.Helpers
{
    public class FormCompletionHelper : PageInteractionHelper
    {
        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void ClickElement(By locator)
        {
            WebDriver.FindElement(locator).Click();
        }

        public static void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterText(By locator, string text)
        {
            WebDriver.FindElement(locator).Clear();
            WebDriver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(IWebElement element, int value)
        {
            element.Clear();
            element.SendKeys(value.ToString());
        }

        public static void SelectFromDropDownByValue(IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public static void SelectFromDropDownByText(IWebElement element, string text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void SelectCheckBox(IWebElement element)
        {
            if(element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public static void SelectRadioOptionByForAttribute(By locator, string forAttribute)
        {
            IList<IWebElement> radios = WebDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }
    }
}