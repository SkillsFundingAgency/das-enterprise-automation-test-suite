using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Review changes";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmChangesOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.Id("submit-review-changes");

        public ProviderReviewChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderEditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            SelectConfirmChangesOptions("changes-approved-true")
            .Continue();
            return new ProviderEditedApprenticeDetailsPage(_context);
        }

        public ProviderApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            SelectConfirmChangesOptions("changes-approved-false")
            .Continue();
            return new ProviderApprenticeDetailsPage(_context);
        }

        private ProviderReviewChangesPage SelectConfirmChangesOptions(string option)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, option);
            return this;
        }
    }
}
