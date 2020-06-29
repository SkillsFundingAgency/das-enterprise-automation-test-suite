using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm cohort deletion";

        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");

        protected override By ContinueButton => By.CssSelector("#submit-delete-cohort");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmCohortDeletionPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderYourCohortsPage ConfirmDeleteAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "DeleteConfirmed-True");
            Continue();
            return new ProviderYourCohortsPage(_context);
        }
    }
}
