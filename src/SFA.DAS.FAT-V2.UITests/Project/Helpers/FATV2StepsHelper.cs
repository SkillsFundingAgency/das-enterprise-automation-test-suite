using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Helpers
{
    public class FATV2StepsHelper
    {
        private readonly ScenarioContext _context;

        public FATV2StepsHelper(ScenarioContext context) => _context = context;

        public TrainingCourseSearchResultsPage SearchForTrainingCourse(string course = "") => new FATV2IndexPage(_context).ClickStartButton().SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(course);

        public ProviderSummaryPage SelectASpecificProvider(string provider = "")
        {
            new ProviderSearchResultsPage(_context).ClickSpecifiedProvider(provider);

            return new ProviderSummaryPage(_context);
        }

        public ProviderSearchResultsPage SelectTrainingCourseAndNavigateToProviderListPage(string course = "")
        {
            return SearchForTrainingCourse(course)
                .SelectFirstTrainingResult()
                .ClickViewProvidersForThisCourse();
        }

        public ProviderShortlistPage ShortlistATrainingCourseAndNavigateToShortlistPage(string course = "")
        {
           return SearchForTrainingCourse(course)
                .SelectFirstTrainingResult()
                .ClickViewProvidersForThisCourse()
                .ShortlistAProviderFromProviderList()
                .NavigateToProviderShortlistPage();
        }
    }
}
