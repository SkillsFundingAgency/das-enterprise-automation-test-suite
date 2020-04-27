using NUnit.Framework;
using SFA.DAS.FAT.UITests.Project.Helpers;
using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FATSteps
    {
        private readonly ScenarioContext _context;
        private readonly FATStepsHelper _fATStepsHelper;
        private TrainingCourseSearchResultsPage _trainingCourseSearchResultsPage;
        private ProviderSearchResultsPage _providerSearchResultsPage;
        private FindATrainingProviderPage _findATrainingProviderPage;

        public FATSteps(ScenarioContext context)
        {
            _context = context;
            _fATStepsHelper = new FATStepsHelper(_context);
        }

        [Given(@"the User navigates to the Search Results page")]
        [When(@"the User navigates to the Search Results page")]
        public void WhenTheUserNavigatesToTheSearchResultsPage() => _trainingCourseSearchResultsPage = _fATStepsHelper.SearchForTrainingCourse();

        [Then(@"the Search Results page features are displayed")]
        public void ThenTheSearchResultsPageFeaturesAreDisplayed() => _trainingCourseSearchResultsPage.VerifyFilterAndSortByFields();

        [When(@"the User selects level (2|3|4|5|6|7) to filter results")]
        public void WhenTheUserSelectsLevelToFilterResults(string level) => _trainingCourseSearchResultsPage = _trainingCourseSearchResultsPage.SelectLevelAndFilterResults(level);

        [Then(@"only the level (2|3|4|5|6|7) Search Results are displayed")]
        public void ThenOnlyTheLevelSearchResultsAreDisplayed(string level) => _trainingCourseSearchResultsPage = _trainingCourseSearchResultsPage.VerifyLevelInfoFromSearchResults(level);

        [When(@"the User searches with (.*) term")]
        public void WhenTheUserSearchesWithATerm(string training) => _trainingCourseSearchResultsPage = _fATStepsHelper.SearchForTrainingCourse(training);

        [Then(@"the User is able to choose the first training from the results displayed")]
        public void ThenTheUserIsAbleToChooseTheFirstTrainingFromTheResultsDisplayed() =>
            _findATrainingProviderPage = _trainingCourseSearchResultsPage.SelectFirstTrainingResult().ClickFindTrainingProvidersButton();

        [Then(@"the User is able to find the Provider by location (.*) for the chosen training")]
        public void ThenTheUserIsAbleToFindTheProviderByPostCodeForTheChosenTraining(string postCode)
        {
            _providerSearchResultsPage = _findATrainingProviderPage.EnterPostCodeAndSearch(postCode);
            _fATStepsHelper.CheckIfSatisfactionAndAchievementRatesAreDisplayed(_providerSearchResultsPage);
        }

        [When(@"the User chooses to diplay results in (ascending order|descending order) of Apprenticeship Level")]
        public void WhenTheUserChoosesToDiplayResultsInAscendingOrderOfApprenticeshipLevel(string order)
        {
            if (order.Contains("ascending order"))
                _trainingCourseSearchResultsPage.SelectAscendingOrderSort();
            else
                _trainingCourseSearchResultsPage.SelectDescendingOrderSort();
        }

        [Then(@"the results are displayed in (ascending order|descending order)")]
        public void ThenTheResultsAreDisplayedInAscendingOrder(string order)
        {
            var levelInfo = _trainingCourseSearchResultsPage.GetLevelInfoFromResults();

            if (order.Contains("ascending order"))
                CollectionAssert.IsOrdered(levelInfo);
            else
                CollectionAssert.IsOrdered(levelInfo.Reverse());
        }
    }
}
