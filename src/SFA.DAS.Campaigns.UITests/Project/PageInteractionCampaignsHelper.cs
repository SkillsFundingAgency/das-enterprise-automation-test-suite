using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SFA.DAS.Campaigns.UITests
{
    public class PageInteractionCampaignsHelper
    {
        protected IWebDriver WebDriver;
        public static string expectedVacancyTitle = "";
        internal static string expectedVacancyDescription = "";
        internal static string expectedEmployerName = "";
        internal static string expectedPossibleClosingDate = "";

        public PageInteractionCampaignsHelper(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void switchToANewTab()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());

            /*ArrayList<String> tabs = new ArrayList<String>(driver.getWindowHandles());
            driver.switchTo().window(tabs.get(1));
            driver.close();
            driver.switchTo().window(tabs.get2));*/
        }
    }
}