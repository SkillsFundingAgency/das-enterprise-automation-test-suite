using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrainingProviderPage(ScenarioContext context): base(context)
        {
            _context = context;
            VerifyPage();
        }

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            SelectRadioOptionByForAttribute("UseThisProvider");
            Continue();
            return new StartAddingApprenticesPage(_context);
        }
    }
}