using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderUnderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        internal TrainingProviderAddedPage ConfirmTrainingProvider()
        {
            SelectRadioOptionByForAttribute("choice-1");
            Continue();
            return new TrainingProviderAddedPage(_context);
        }
    }
}

