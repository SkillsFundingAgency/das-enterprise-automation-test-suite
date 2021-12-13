using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_YourWithdrawalRequestsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Your withdrawal requests";
        
        #region Locators
        private By StandardNameVerification => By.XPath("//a[contains(text(),'Create a new withdrawal request')]");
        private By Status(string status) => By.XPath($"//td[contains(text(),'{status}')]");
        private By ViewRegisterWithdrawalFeedbackLink => By.XPath("//tr/td[contains(text(),'Register')]/../td[contains(text(), 'Not applicable')]/../td[contains(text(),'Feedback added')]/../td/a");
        #endregion

        public AS_YourWithdrawalRequestsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WhatAreYouWithdrawingFromPage ClickStartNewWithdrawalNotification()
        {
            formCompletionHelper.Click(StandardNameVerification);
            return new AS_WhatAreYouWithdrawingFromPage(context);
        }

        public void ValidateStatus(string status) => Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Status(status)), $"Validate status:[{status}] exists on the page");

        public AS_WithdrawalRequestOverviewPage ClickOnViewLinkForInProgressApplication()
        {
            tableRowHelper.SelectRowFromTable("View", "In progress");
            return new AS_WithdrawalRequestOverviewPage(context);
        }

        public AS_FeedbackOnYourWithdrawalNotificationStartPage ClickViewOnRegisterWithdrawalWithFeedbackAdded()
        {
            formCompletionHelper.Click(ViewRegisterWithdrawalFeedbackLink);
            return new AS_FeedbackOnYourWithdrawalNotificationStartPage(context);
        }

    }
}
