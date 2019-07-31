using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
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
        }

        public bool compareContentOfTwoArraylists(ArrayList actualArrayList, ArrayList expectedArrayList)
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
    }
}