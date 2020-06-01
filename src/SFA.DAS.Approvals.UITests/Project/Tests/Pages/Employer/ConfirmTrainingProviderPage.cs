using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm training provider";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrainingProviderPage(ScenarioContext context): base(context) => _context = context;

        public StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            SelectRadioOptionByForAttribute("UseThisProvider");
            Continue();
            return new StartAddingApprenticesPage(_context);
        }
    }
}
