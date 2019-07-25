using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class JavaScriptHelper
    {
        private readonly IWebDriver _webDriver;

        public JavaScriptHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", webElement);
        }
    }
}
