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

        protected By ButtonCssSelector => By.CssSelector(".button");

        protected By RadioButtonCssSelector => By.CssSelector("label.selection-button-radio");

        protected By CheckBoxCssSelector => By.CssSelector("label.selection-button-checkbox");

        public WebElementInteractionHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        protected IWebElement GetElementByText(By locator, String text)
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

        protected SelectElement SelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}