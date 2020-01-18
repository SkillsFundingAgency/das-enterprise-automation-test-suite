using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm deletion";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmCohortDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourCohortRequestsPage ConfirmDeleteAndSubmit()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            Continue();
            return new YourCohortRequestsPage(_context);
        }
    }
}