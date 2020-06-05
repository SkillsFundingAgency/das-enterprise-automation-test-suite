using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm apprentice deletion";

        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");

        protected override By ContinueButton => By.CssSelector(".button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmApprenticeDeletionPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "DeleteConfirmed-True");
            Continue();
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
