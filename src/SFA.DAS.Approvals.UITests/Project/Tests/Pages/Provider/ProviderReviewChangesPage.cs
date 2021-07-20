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

        private By ConfirmChangesOptions => By.CssSelector(".govuk-radios__label"); 
        protected override By ContinueButton => By.CssSelector("#continue-button");        

        public ProviderReviewChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderEditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            SelectConfirmChangesOptions("AcceptChanges")
            .Continue();
            return new ProviderEditedApprenticeDetailsPage(_context);
        }

        public ProviderApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            SelectConfirmChangesOptions("AcceptChanges-no")
            .Continue();
            return new ProviderApprenticeDetailsPage(_context);
        }

        private ProviderReviewChangesPage SelectConfirmChangesOptions(string option)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, option);
            return this;
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
    }
}
