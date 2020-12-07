using NUnit.Framework;
using SFA.DAS.FAT_V2.UITests.Project.Helpers;
using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FATV2Steps
    {
        private readonly ScenarioContext _context;
        private readonly FATV2StepsHelper _fATV2StepsHelper;
        private TrainingCourseSearchResultsPage _trainingCourseSearchResultsPage;
        private TrainingCourseSummaryPage _trainingCourseSummaryPage;
        private ProviderSearchResultsPage _providerSearchResultsPage;
        private ProviderSummaryPage _providerSummaryPage;

        public FATV2Steps(ScenarioContext context)
        {
            _context = context;
            _fATV2StepsHelper = new FATV2StepsHelper(_context);
        }

        [Given(@"the User navigates to the Search Results page")]
        [When(@"the User navigates to the Search Results page")]
        public void WhenTheUserNavigatesToTheSearchResultsPage() => _trainingCourseSearchResultsPage = _fATV2StepsHelper.SearchForTrainingCourse();

        [When(@"the User selects level (2|3|4|5|6|7) to filter results")]
        public void WhenTheUserSelectsLevelToFilterResults(string level) => _trainingCourseSearchResultsPage = _trainingCourseSearchResultsPage.SelectLevelAndFilterResults(level);

        [Then(@"only the level (2|3|4|5|6|7) Search Results are displayed")]
        public void ThenOnlyTheLevelSearchResultsAreDisplayed(string level) => _trainingCourseSearchResultsPage = _trainingCourseSearchResultsPage.VerifyLevelInfoFromSearchResults(level);
        [Given(@"the User searches with (.*) term")]
        [When(@"the User searches with (.*) term")]

        public void WhenTheUserSearchesWithATerm(string training) => _trainingCourseSearchResultsPage = _fATV2StepsHelper.SearchForTrainingCourse(training);

        [When(@"the User chooses to diplay results in '(Name|Relevance)' order")]
        public void WhenTheUserChoosesToDiplayResultsInOrder(string order)
        {
            if (order.Contains("Name"))
                _trainingCourseSearchResultsPage.SelectNameOrderSort();
            else
                _trainingCourseSearchResultsPage.SelectRelevanceOrderSort();
        }

        [When(@"the User chooses the first course from the Search Results page")]
        [Given(@"the User chooses the first course from the Search Results page")]
        public void WhenTheUserChoosesTheFirstCourseFromTheSearchResultsPage()
        {
            _trainingCourseSummaryPage = _trainingCourseSearchResultsPage.SelectFirstTrainingResult();
        }

        [Then(@"the '(Name |Relevance)' link is displayed")]
        public void ThenTheLinkIsDisplayed(string relevance) => _trainingCourseSearchResultsPage = _trainingCourseSearchResultsPage.VerifySortByInfoFromSearchResults(relevance);

        [Then(@"User is able to return to homepage")]
        public void ThenUserIsAbleToReturnToHomepage() => _trainingCourseSummaryPage.NavigateBackToHompage();

        [Then(@"the User is able to find the Provider by location (.*) for the chosen training")]
        public void ThenTheUserIsAbleToFindTheProviderByPostCodeForTheChosenTraining(string postCode)
        {
            _providerSearchResultsPage = _trainingCourseSummaryPage.EnterPostCodeAndSearch(postCode);
        }

        [Then(@"the User is able to select the Provider for the chosen training")]
        public void ThenTheUserIsAbleToSelectTheProviderForTheChosenTraining()
        {
            _providerSummaryPage = _providerSearchResultsPage.SelectFirstProviderInTheList();
        }

        [Given(@"the User searches a course then navigates to the provider list")]
        public void GivenTheUserSearchesACourseThenNavigatesToTheProviderList()
        {
            WhenTheUserSearchesWithATerm("Advanced golf");
            WhenTheUserChoosesTheFirstCourseFromTheSearchResultsPage();

            _providerSearchResultsPage = _trainingCourseSummaryPage.ClickViewProvidersForThisCourse();
        }

        [When(@"the User selects (.*) from the list")]
        public void WhenTheUserSelectsAProviderFromTheList(string provider) => _providerSummaryPage = _fATV2StepsHelper.SelectASpecificProvider(provider);

        [When(@"enters the location (.*)")]
        public void WhenEntersTheSearchedLocation(string location) => _providerSummaryPage.EnterPostCodeAndSearch(location);

        [Then(@"'(.*)' message is displayed")]
        public void ThenMessageIsDisplayed(string errorMessage) => Assert.IsTrue(_providerSummaryPage.VerifyNoTrainingProviderAtLocationErrorText(), errorMessage);

        [Given(@"user navigates to provider details page")]
        public void GivenUserNavigatesToProviderDetailsPage()
        {
            GivenTheUserSearchesACourseThenNavigatesToTheProviderList();
            ThenTheUserIsAbleToSelectTheProviderForTheChosenTraining();
        }

        [Then(@"user is able to navigate to homepage using the breadcrumbs")]
        public void ThenUserIsAbleToNavigateToHomepageUsingTheBreadcrumbs() => _providerSummaryPage.NavigateBackFromProviderSummaryPage()
            .NavigateBackFromTrainingProvidersPage()
            .NavigateBackFromCourseSummaryPage()
            .NavigateBackToHompage();
    }
}
