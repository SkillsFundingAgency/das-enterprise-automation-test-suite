using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderMessageForEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Message for employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MessageBox => By.Id("Message");
        private By SendButton => By.CssSelector(".button");

        public ProviderMessageForEmployerPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderCohortApprovedAndSentToEmployerPage SendInstructionsToEmployerForAnApprovedCohort()
        {
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToEmployer);
            formCompletionHelper.ClickElement(SendButton);
            return new ProviderCohortApprovedAndSentToEmployerPage(_context);
        }
        public  ProviderCohortSentForReviewPage SendInstructionsToEmployerForCohortToReview()
        {
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToEmployer);
            formCompletionHelper.ClickElement(SendButton);
            return new ProviderCohortSentForReviewPage(_context);
        }
    }
}
