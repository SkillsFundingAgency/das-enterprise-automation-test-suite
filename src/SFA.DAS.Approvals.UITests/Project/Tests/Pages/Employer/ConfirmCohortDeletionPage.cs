using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmCohortDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm deletion";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public ConfirmCohortDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
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
