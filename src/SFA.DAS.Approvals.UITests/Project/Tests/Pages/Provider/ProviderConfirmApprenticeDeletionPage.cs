using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm apprentice deletion";

        private By ConfirmDeleteOptions => By.Id("confirm-true");

        protected By SaveAndContinueButton => By.Id("saveBtn");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmApprenticeDeletionPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
