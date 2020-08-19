using NUnit.Framework;
using SFA.DAS.FAT_V2.UITests.Project.Helpers;
using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class FATV2Steps
    {
        private readonly ScenarioContext _context;
        private readonly FATV2StepsHelper _fATV2StepsHelper;
        private TrainingCourseSearchResultsPage _trainingCourseSearchResultsPage;
        private ProviderSearchResultsPage _providerSearchResultsPage;
        private FindATrainingProviderPage _findATrainingProviderPage;
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

    }
}
