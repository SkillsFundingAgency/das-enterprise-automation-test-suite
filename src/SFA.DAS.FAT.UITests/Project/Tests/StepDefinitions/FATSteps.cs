using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FATSteps
    {
        private readonly ScenarioContext _context;
        private SearchResultsPage searchResultsPage;

        public FATSteps(ScenarioContext context) => _context = context;

        [Given(@"the User navigates to the Search Results page")]
        [When(@"the User navigates to the Search Results page")]
        public void WhenTheUserNavigatesToTheSearchResultsPage() =>
            searchResultsPage = new FATIndexPage(_context).ClickStartButton().SearchApprenticeshipInFindApprenticeshipTrainingSearchPage();

        [Then(@"the Search Results page features are displayed")]
        public void ThenTheSearchResultsPageFeaturesAreDisplayed() => searchResultsPage.VerifyFilterAndSortByFields();

        [When(@"the User selects level (2|3|4|5|6|7) to filter results")]
        public void WhenTheUserSelectsLevelToFilterResults(string level) => searchResultsPage = searchResultsPage.SelectLevelAndFilterResults(level);

        [Then(@"only the level (2|3|4|5|6|7) Search Results are displayed")]
        public void ThenOnlyTheLevelSearchResultsAreDisplayed(string level) => searchResultsPage = searchResultsPage.VerifyLevelInfoFromSearchResults(level);
    }
}
