using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalRequestOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal request overview";
        
        #region Locators
        private By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
        private By InitialQuestionsCompletedVerification => By.XPath("//*[contains(text(),'0 of 4 questions completed')]");
        private By TotalQuestionsCompletedVerification => By.XPath("//*[contains(text(),'4 of 4 questions completed')]");
        private By TotalQuestionsWithAdditionalHowWillYouSupportLearnersCompletedVerification => By.XPath("//*[contains(text(),'5 of 5 questions completed')]");
        private By StartStandardWithdrawalQuestions => By.LinkText("Go to withdrawal request questions");
        private By StartOrganisationWithdrawalQuestions => By.LinkText("Go to withdrawal request questions");
      
        private By AmmedSupportingCurrentLearnersAnswer => By.XPath("//strong/../span/a[contains(text(), 'Supporting current learners')]");
        #endregion
        public AS_WithdrawalRequestOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WithdrawalRequestQuestionsPage ClickGoToStandardWithdrawalQuestions()
        {
            VerifyPage(StandardNameVerification, "ST0580 Brewer");
            VerifyPage(InitialQuestionsCompletedVerification, "0 of 4 questions completed");
            formCompletionHelper.Click(StartStandardWithdrawalQuestions);
            return new AS_WithdrawalRequestQuestionsPage(context);
        }

        public AS_WithdrawalRequestQuestionsPage ClickGoToRegisterWithdrawalQuestions()
        {
            VerifyPage(PageCaptionXl, "Withdrawing from register");
            VerifyPage(InitialQuestionsCompletedVerification, "0 of 4 questions completed");
            formCompletionHelper.Click(StartOrganisationWithdrawalQuestions);
            return new AS_WithdrawalRequestQuestionsPage(context);
        }

        public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage ClickSupportingCurrentLearnersFeedback()
        {
            formCompletionHelper.Click(AmmedSupportingCurrentLearnersAnswer);
            return new AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage(context);
        }

        public void AcceptAndSubmit()
        {
            VerifyPage(TotalQuestionsCompletedVerification, "4 of 4 questions completed");
            Continue();
        }

        public void SubmitUpdatedAnswers()
        {
            Continue();
        }

        public void AcceptAndSubmitWithHowWillYouSuportQuestion()
        {
            VerifyPage(TotalQuestionsWithAdditionalHowWillYouSupportLearnersCompletedVerification, "5 of 5 questions completed");
            Continue();
        }
    }
}