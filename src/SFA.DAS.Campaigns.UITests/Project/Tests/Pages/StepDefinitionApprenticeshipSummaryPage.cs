using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionApprenticeshipSummaryPage
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly ApprenticeshipSummaryPage apprenticeshipSummaryPage;
        #endregion

        public StepDefinitionApprenticeshipSummaryPage(ScenarioContext context)
        {
            _context = context;
            apprenticeshipSummaryPage = new ApprenticeshipSummaryPage(_context);
        }

        [Then(@"I can verify Apprentice Details Of Results Page Against Apprentice Details of Summary page")]
        public void ICanSeeApprenticeshipSummaryPage()
        {
            apprenticeshipSummaryPage.VerifyApprenticeDetailsOfResultsPageAgainstSummaryPage();
            apprenticeshipSummaryPage.ClickObSignInToApplyButton();
        }
    }
}