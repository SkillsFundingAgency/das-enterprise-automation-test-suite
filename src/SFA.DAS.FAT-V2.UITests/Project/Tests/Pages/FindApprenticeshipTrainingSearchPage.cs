using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class FindApprenticeshipTrainingSearchPage : FATV2BasePage
    {
        protected override string PageTitle => "Apprenticeship training courses";

        protected override bool TakeFullScreenShot => false;

        public FindApprenticeshipTrainingSearchPage(ScenarioContext context) : base(context) { }

        public TrainingCourseSearchResultsPage SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(string searchTerm)
        {
            SearchApprenticeship(searchTerm);
            return new TrainingCourseSearchResultsPage(context);
        }
    }
}
