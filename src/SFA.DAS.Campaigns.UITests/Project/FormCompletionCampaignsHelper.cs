using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Campaigns.UITests
{
    public class FormCompletionCampaignsHelper : PageInteractionHelper
    {
        public FormCompletionCampaignsHelper(IWebDriver webDriver) :base(webDriver)
        {

        }

        public void SelectFromDropDownByValue(By byLocator, string value)
        {
            IWebElement element = WebDriver.FindElement(byLocator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public void SelectFromDropDownByText(By byLocator, string text)
        {
            IWebElement element = WebDriver.FindElement(byLocator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }
    }
}