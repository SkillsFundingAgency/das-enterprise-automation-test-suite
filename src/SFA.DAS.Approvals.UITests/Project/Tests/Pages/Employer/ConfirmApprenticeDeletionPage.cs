using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage : BasePage
    {
        protected override string PageTitle => "Delete the apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        internal ReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirmDelete-true");
            Continue();
            return new ReviewYourCohortPage(_context);
        }
    }
}