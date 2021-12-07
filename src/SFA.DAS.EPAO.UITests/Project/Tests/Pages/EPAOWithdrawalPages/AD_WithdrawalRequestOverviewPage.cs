using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalRequestOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal application overview";

        private readonly ScenarioContext _context;

        private By CompleteReviewButton => By.CssSelector("button.govuk-button");
        private By Tag => By.CssSelector("div.govuk-tag");

        public AD_WithdrawalRequestOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AD_WithdrawalRequestQuestionsPage GoToWithdrawalRequestQuestionsPage()
        {
            formCompletionHelper.ClickLinkByText("Evaluate withdrawal application");
            return new AD_WithdrawalRequestQuestionsPage(_context);
        }

        public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to withdrawal applications");
            return new AD_WithdrawalApplicationsPage(_context);
        }

        public AD_WithdrawalRequestOverviewPage VerifyAnswerUpdatedTag()
        {
            Assert.AreEqual("ANSWER UPDATED", pageInteractionHelper.GetText(Tag));
            return this;
        }

        public AD_CheckTheWithdrawDatePage ClickCompleteReview()
        {
            formCompletionHelper.Click(CompleteReviewButton);
            return new AD_CheckTheWithdrawDatePage(_context);
        }
    }
}
