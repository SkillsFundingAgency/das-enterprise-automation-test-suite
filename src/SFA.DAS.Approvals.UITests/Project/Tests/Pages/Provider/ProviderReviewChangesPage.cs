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

        protected override By ContinueButton => By.CssSelector("#continue-button");        

        public ProviderReviewChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderEditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            SelectOption("Yes, approve these changes");
            
            return new ProviderEditedApprenticeDetailsPage(_context);
        }

        public ProviderApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            SelectOption("No, reject these changes");

            return new ProviderApprenticeDetailsPage(_context);
        }

        public ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            Continue();
            return new ProviderAccessDeniedPage(_context);
        }

        public ProviderReviewChangesPage SelectReviewChangesOptions()
        {
            Continue();
            return this;
        }

        private void SelectOption(string radioOption) { SelectRadioOptionByText(radioOption); Continue(); }
    }
}
