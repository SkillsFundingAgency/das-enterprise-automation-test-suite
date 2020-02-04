using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionYourResultsPage
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly YourResultsPage yourResultsPage;
        private RegisterMyInterestPage registerMyInterestPage;
        #endregion

        public StepDefinitionYourResultsPage(ScenarioContext context)
        {
            _context = context;
            yourResultsPage = new YourResultsPage(_context);
        }

        [Then(@"I click on first search result")]
        public void ClickOnFirstSearchResult()
        {
            yourResultsPage.VerifyResultsPageHeader();
            TestContext.Progress.WriteLine("Navigating to Apprenticeship Summary page");
            yourResultsPage.ClickOnAnySerachResult();
        }

        [Then(@"I can verify the content of no matching results page")]
        public void VerifyContentInNoMatchingResultsPage()
        {
            yourResultsPage.VerifyResultsPageHeader();
            yourResultsPage.VerifyTheNoMatchResultsPageContent();
        }

    }
}