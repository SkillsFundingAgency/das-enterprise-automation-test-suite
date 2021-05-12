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

        private By ConfirmChangesOptions => By.CssSelector(".govuk-radios__input");
        protected override By ContinueButton => By.CssSelector("#continue-button");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByLocator(By.CssSelector("#ApproveChanges"));
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