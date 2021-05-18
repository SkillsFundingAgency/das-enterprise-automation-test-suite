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

        private By RadioButtonYes => By.CssSelector("#ApproveChanges, #changes-approve-true");
        private By RadioButtonNo => By.CssSelector("#ApproveChanges-no, #changes-approve-false");
        protected override By ContinueButton => By.CssSelector("#continue-button, #submit-req-changes");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByLocator(RadioButtonYes);
            Continue();
            return new EditedApprenticeDetailsPage(_context);
        }

        public ApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByLocator(RadioButtonNo);
            Continue();
            return new ApprenticeDetailsPage(_context);
        }
    }
}