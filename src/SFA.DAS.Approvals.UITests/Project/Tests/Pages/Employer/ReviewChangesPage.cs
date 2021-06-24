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

        protected override By ContinueButton => By.Id("continue-button");

        public EditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            Continue();
            return new EditedApprenticeDetailsPage(_context);
        }

        public ApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "No");
            Continue();
            return new ApprenticeDetailsPage(_context);
        }
    }
}