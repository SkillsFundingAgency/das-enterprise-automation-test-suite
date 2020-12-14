using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_YourWithdrawalNotificationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Your withdrawal notifications";
        private readonly ScenarioContext _context;
        
        #region Locators
        private By StandardNameVerification => By.XPath("//a[contains(text(),'Create a new withdrawal notification')]");
        private By Status(string status) => By.XPath($"//td[contains(text(),'{status}')]");
        #endregion

        public AS_YourWithdrawalNotificationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatAreYouWithdrawingFromPage ClickStartNewWithdrawalNotification()
        {
            formCompletionHelper.Click(StandardNameVerification);
            return new AS_WhatAreYouWithdrawingFromPage(_context);
        }

        public void ValidateStatus(string status) => Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Status(status)), $"Validate status:[{status}] exists on the page");

        public AS_ApplicationOverviewPage ClickOnViewLinkForInProgressApplication()
        {
            tableRowHelper.SelectRowFromTable("View", "In progress");
            return new AS_ApplicationOverviewPage(_context);
        }


    }
}
