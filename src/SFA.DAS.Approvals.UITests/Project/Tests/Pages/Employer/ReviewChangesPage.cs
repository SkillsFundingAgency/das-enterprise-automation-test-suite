using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Review changes";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReviewChangesPage(ScenarioContext context) : base(context) => _context = context;

        private By ConfirmChangesOptions => By.CssSelector(".selection-button-radio");

        protected override By ContinueButton => By.CssSelector(".button");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, "changes-approve-true");
            Continue();
            return new EditedApprenticeDetailsPage(_context);
        }

        public ApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmChangesOptions, "changes-approve-false");
            Continue();
            return new ApprenticeDetailsPage(_context);
        }
    }
}