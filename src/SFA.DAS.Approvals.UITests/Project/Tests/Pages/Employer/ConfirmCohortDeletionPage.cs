using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm deletion";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmCohortDeletionPage(ScenarioContext context) : base(context) => _context = context;

        public YourCohortRequestsPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            Continue();
            return new YourCohortRequestsPage(_context);
        }
    }
}
