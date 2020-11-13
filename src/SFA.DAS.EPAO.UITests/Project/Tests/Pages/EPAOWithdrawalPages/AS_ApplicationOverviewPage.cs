using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_ApplicationOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Application overview";
        private readonly ScenarioContext _context;

        #region Locators
        private By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
        private By InitialQuestionsCompletedVerification => By.XPath("//*[contains(text(),'0 of 4 questions completed')]");
        private By TotalQuestionsCompletedVerification => By.XPath("//*[contains(text(),'4 of 4 questions completed')]");
        private By StartStandardWithdrawalQuestions => By.LinkText("Go to withdrawal notification questions");
        private By StartOrgnisationWithdrawalQuestions => By.LinkText("Go to withdrawal notification questions");
        #endregion
        public AS_ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WithdrawalNotificationQuestionsPage ClickGoToStandardWithdrawalQuestions()
        {
            VerifyPage(StandardNameVerification, "ST0580 Brewer");
            VerifyPage(InitialQuestionsCompletedVerification, "0 of 4 questions completed");
            formCompletionHelper.Click(StartStandardWithdrawalQuestions);
            return new AS_WithdrawalNotificationQuestionsPage(_context);
        }

        public void AcceptAndSubmit()
        {
            VerifyPage(TotalQuestionsCompletedVerification, "4 of 4 questions completed");
            Continue();
        }
    }
}