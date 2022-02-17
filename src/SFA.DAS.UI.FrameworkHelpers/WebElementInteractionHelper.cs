using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class WebElementInteractionHelper
    {
        private readonly IWebDriver _webDriver;

        protected By LinkCssSelector => By.CssSelector("a");

        protected By InputCssSelector => By.CssSelector(".govuk-input");

        protected By ButtonCssSelector => By.CssSelector(".button");

        protected By RadioButtonInputCssSelector => By.CssSelector("input.govuk-radios__input");

        protected By RadioButtonLabelCssSelector => By.CssSelector("label.selection-button-radio, label.govuk-radios__label");

        protected By CheckBoxCssSelector => By.CssSelector("label.selection-button-checkbox");

        protected WebElementInteractionHelper(IWebDriver webDriver) => _webDriver = webDriver;

        protected IWebElement GetElementByText(By locator, string expectedvalue) => GetElementByAttribute(locator, expectedvalue, (IWebElement e) => e.Text ?? e.GetAttribute(AttributeHelper.InnerText));

        protected IWebElement GetElementByAttribute(By locator, string attribute, string expectedvalue) => GetElementByAttribute(locator, expectedvalue, (IWebElement e) => e.GetAttribute(attribute));

        protected IWebElement GetElementByAttribute(By locator, string expectedvalue, Func<IWebElement, string> actualValue)
        {
            IList<IWebElement> elements = _webDriver.FindElements(locator);

            for (int i = 0; i < elements.Count; i++) if (actualValue(elements[i]).Contains(expectedvalue)) return elements[i];

            return null;
        }

        protected SelectElement SelectElement(IWebElement element) => new SelectElement(element);

        protected SelectElement SelectElement(By by) => SelectElement(_webDriver.FindElement(by));
    }
}