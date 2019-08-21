using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;

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
        }

        public bool compareContentOfTwoArraylists(IList<string> actualArrayList, IList<string> expectedArrayList)
        {
            if (actualArrayList.Count == expectedArrayList.Count)
            {
                for (int i = 0; i < actualArrayList.Count; i++)
                {
                    if (actualArrayList[i].ToString().Contains(expectedArrayList[i].ToString())){
                        if (i == actualArrayList.Count - 1)
                        {
                            return true;
                        }
                        continue;
                    }

                    throw new Exception("Text verification failed: "
                    + "\n Expected: " + expectedArrayList[i].ToString()
                    + "\n Found: " + actualArrayList[i].ToString());
                }
            }

            throw new Exception("Arraylist size verification failed: "
            + "\n Actual array list size is : " + actualArrayList.Count
            + "\n Expected array list size is : " + expectedArrayList.Count);
        }

        public string GetText(string property)
        {
            var webElement = WebDriver.FindElement(By.XPath(property));
            return webElement.Text;
        }

        public void FocusTheElement(string strXPath)
        {
            IWebElement webElement = WebDriver.FindElement(By.XPath(strXPath));
            IJavaScriptExecutor je = (IJavaScriptExecutor)WebDriver;
            je.ExecuteScript("arguments[0].scrollIntoView(false);", webElement);
        }

        public void navigateToAnyVideoUrl(By byLocator)
        {
            var webElement = WebDriver.FindElement(byLocator);
            string videoUrl = webElement.GetAttribute("data-videourl");
            WebDriver.Navigate().GoToUrl(videoUrl);
            //System.Threading.Thread.Sleep(3000);
        }

        public void navigateBack()
        {
            WebDriver.Navigate().Back();
            //System.Threading.Thread.Sleep(3000);
        }
    }
}