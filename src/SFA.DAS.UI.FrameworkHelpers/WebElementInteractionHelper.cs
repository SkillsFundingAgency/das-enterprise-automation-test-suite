using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<IWebElement> GetElementsByText(By locator, string expectedvalue) => GetElementsByAttribute(locator, expectedvalue, (IWebElement e) => e.Text ?? e.GetAttribute(AttributeHelper.InnerText));

        protected IWebElement GetElementByText(By locator, string expectedvalue) => GetElementsByText(locator, expectedvalue).FirstOrDefault();

        protected IWebElement GetElementByAttribute(By locator, string attribute, string expectedvalue) => GetElementsByAttribute(locator, expectedvalue, (IWebElement e) => e.GetAttribute(attribute)).FirstOrDefault();

        private List<IWebElement> GetElementsByAttribute(By locator, string expectedvalue, Func<IWebElement, string> actualValue)
        {
            List<IWebElement> elements = new();

            foreach (var e in _webDriver.FindElements(locator))
            {
                if (actualValue(e).Contains(expectedvalue)) elements.Add(e);
            }

            return elements;
        }


        protected SelectElement SelectElement(IWebElement element) => new SelectElement(element);

        protected SelectElement SelectElement(By by) => SelectElement(_webDriver.FindElement(by));
    }
}