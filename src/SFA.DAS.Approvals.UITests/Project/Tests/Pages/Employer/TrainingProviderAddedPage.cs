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

        private By ReturnToTrainingProviders => By.CssSelector(".govuk-button");

        public TrainingProviderAddedPage(ScenarioContext context) : base(context) => _context = context;

        public YourTrainingProvidersPage SelectContinueInEmployerTrainingProviderAddedPage()
        {
            formCompletionHelper.ClickElement(ReturnToTrainingProviders);
            return new YourTrainingProvidersPage(_context);
        }
    }
}