using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalRequestQuestionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal request questions";
        private readonly ScenarioContext _context;

        #region Locators
        private By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
        private By GoToReasonForWithdrawingQuestionsLink => By.LinkText("Reason for withdrawing");
        private By ReaasonForWithdrawingCompletedVerification => By.XPath("//a[contains(text(), 'Reason for withdrawing')]/../following-sibling::strong");
        private By CompletingAssessmentsForLearnersCompletedVerification => By.XPath("//a[contains(text(), 'Completing assessments for registered learners')]/../following-sibling::strong");
        private By CommunicatingMarketExitCompletedVerification => By.XPath("//a[contains(text(), 'Communicating your market exit to customers')]/../following-sibling::strong");
        private By WithdrawalDateCompletedVerification => By.XPath("//a[contains(text(), 'Withdrawal date')]/../following-sibling::strong");
        private By SupportingLearnersVerification => By.XPath("//a[contains(text(), 'Supporting current learners')]/../following-sibling::strong");
        private By ReturnToApplicationOverviewButton => By.LinkText("Return to application overview");
        #endregion
        public AS_WithdrawalRequestQuestionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage ClickGoToReasonForWithdrawingQuestionLink()
        {
            VerifyPage(StandardNameVerification, "ST0580 Brewer");
            formCompletionHelper.Click(GoToReasonForWithdrawingQuestionsLink);
            return new AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage (_context);
        }

        public AS_WhatIsTheMainReasonYouWantToWithdrawFromTheRegisterPage ClickGoToReasonForWithdrawingFromRegisterQuestionLink()
        {
            formCompletionHelper.Click(GoToReasonForWithdrawingQuestionsLink);
            return new AS_WhatIsTheMainReasonYouWantToWithdrawFromTheRegisterPage(_context);
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

        public AS_ApplicationOverviewPage VerifyWithSupportingLearnersQuestionAndReturnToApplicationOverviewPage()
        {
            VerifyPage(ReaasonForWithdrawingCompletedVerification, "COMPLETED");
            VerifyPage(CompletingAssessmentsForLearnersCompletedVerification, "COMPLETED");
            VerifyPage(CommunicatingMarketExitCompletedVerification, "COMPLETED");
            VerifyPage(WithdrawalDateCompletedVerification, "COMPLETED");
            VerifyPage(SupportingLearnersVerification, "COMPLETED");
            formCompletionHelper.Click(ReturnToApplicationOverviewButton);
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}