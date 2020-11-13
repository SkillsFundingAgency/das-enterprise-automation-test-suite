using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalNotificationQuestionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal notification questions";
        private readonly ScenarioContext _context;

        #region Locators
        private By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
        private By GoToWithdrawalNotificationQuestionsLink => By.LinkText("Reason for withdrawing");
        private By ReaasonForWithdrawingCompletedVerification => By.XPath("(//*[@id='completed'])[1]");
        private By CompletingAssessmentsForLearnersCompletedVerification => By.XPath("(//*[@id='completed'])[2]");
        private By CommunicatingMarketExitCompletedVerification => By.XPath("(//*[@id='completed'])[3]");
        private By WithdrawalDateCompletedVerification => By.XPath("(//*[@id='completed'])[4]");
        private By ReturnToApplicationOverviewButton => By.LinkText("Return to application overview");
        #endregion
        public AS_WithdrawalNotificationQuestionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage ClickGoToWithdrawalNotificationQuestionsLink()
        {
            VerifyPage(StandardNameVerification, "ST0580 Brewer");
            formCompletionHelper.Click(GoToWithdrawalNotificationQuestionsLink);
            return new AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage (_context);
        }

        public AS_ApplicationOverviewPage VerifyAndReturnToApplicationOverviewPage()
        {
            VerifyPage(ReaasonForWithdrawingCompletedVerification, "COMPLETED");
            VerifyPage(CompletingAssessmentsForLearnersCompletedVerification, "COMPLETED");
            VerifyPage(CommunicatingMarketExitCompletedVerification, "COMPLETED");
            VerifyPage(WithdrawalDateCompletedVerification, "COMPLETED");
            formCompletionHelper.Click(ReturnToApplicationOverviewButton);
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}