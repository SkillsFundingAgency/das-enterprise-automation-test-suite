using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class FormCompletionHelper
    {
        protected IWebDriver webDriver;

        public FormCompletionHelper(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void ClickElement(By locator)
        {
            webDriver.FindElement(locator).Click();
        }

        public void EnterText(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void EnterText(By locator, String text)
        {
            webDriver.FindElement(locator).Clear();
            webDriver.FindElement(locator).SendKeys(text);
        }

        public void EnterText(IWebElement element, int value)
        {
            element.Clear();
            element.SendKeys(value.ToString());
        }

        public void SelectFromDropDownByValue(IWebElement element, String value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public void SelectFromDropDownByText(IWebElement element, String text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public void SelectCheckBox(IWebElement element)
        {
            if(element.Displayed && !element.Selected)
            {
                element.Click();
            }
        }

        public void SelectRadioOptionByForAttribute(By locator, String forAttribute)
        {
            IList<IWebElement> radios = webDriver.FindElements(locator);
            var radioToSelect = radios.FirstOrDefault(radio => radio.GetAttribute("for") == forAttribute);

            if (radioToSelect != null)
                ClickElement(radioToSelect);
        }

        public void TakeScreenshotOnFailure()
        {
            try
            {
                Console.WriteLine("************ ************ ************");
                DateTime dateTime = DateTime.Now;
                String failureImageName = dateTime.ToString("HH-mm-ss")
                                    + "_"
                                    + ".png";

                String screenshotsDirectory = AppDomain.CurrentDomain.BaseDirectory
                + "../../"
                + "\\Project\\Screenshots\\"
                + dateTime.ToString("dd-MM-yyyy")
                + "\\";

                if (!Directory.Exists(screenshotsDirectory))
                {
                    Directory.CreateDirectory(screenshotsDirectory);
                }

                ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                Console.WriteLine(" -- Scenario screenshot is available at -- "
                    + screenshotPath);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occurred while taking screenshot - " + exception);
            }
        }
    }
}