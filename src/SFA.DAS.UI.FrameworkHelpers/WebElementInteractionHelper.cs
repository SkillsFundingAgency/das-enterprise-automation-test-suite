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

        protected By RadioButtonCssSelector => By.CssSelector("label.selection-button-radio");

        protected By CheckBoxCssSelector => By.CssSelector("label.selection-button-checkbox");

        protected WebElementInteractionHelper(IWebDriver webDriver) => _webDriver = webDriver;

        protected IWebElement GetElementByText(By locator, String text)
        {
            IList<IWebElement> elements = _webDriver.FindElements(locator);

            for (int i = 0; i < elements.Count; i++)
            {
                String str = elements[i].Text ?? elements[i].GetAttribute("innertext");
                if (str.Contains(text))
                {
                    return elements[i];
                }
            }
            return null;
        }

        protected SelectElement SelectElement(IWebElement element) => new SelectElement(element);
    }
}