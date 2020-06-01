using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Delete the apprentice";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmApprenticeDeletionPage(ScenarioContext context) : base(context) => _context = context;

        internal ReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirmDelete-true");
            Continue();
            return new ReviewYourCohortPage(_context);
        }
    }
}
