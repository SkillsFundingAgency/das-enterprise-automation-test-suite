using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderAddedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "You've successfully added";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public TrainingProviderAddedPage(ScenarioContext context) : base(context) => _context = context;

        public YourTrainingProvidersPage SelectContinueInEmployerTrainingProviderAddedPage()
        { 
            Continue();
            return new YourTrainingProvidersPage(_context);
        }
    }
}