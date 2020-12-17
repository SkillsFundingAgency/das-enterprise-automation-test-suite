using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_StandardWithdrawalApplicationOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Application overview";

        private readonly ScenarioContext _context;

        private By CompleteReviewButton => By.CssSelector("button.govuk-button");

        public AD_StandardWithdrawalApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public AD_WithdrawalNotificationQuestionsPage GoToWithdrawalNotificationQuestionsPage()
        {
            formCompletionHelper.ClickLinkByText("Withdrawal notification questions");
            return new AD_WithdrawalNotificationQuestionsPage(_context);
        }

        public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to withdrawal applications");
            return new AD_WithdrawalApplicationsPage(_context);
        }

        public AD_CompleteReview ClickCompleteReview()
        {
            formCompletionHelper.Click(CompleteReviewButton);
            return new AD_CompleteReview(_context);
        }

    }
}
