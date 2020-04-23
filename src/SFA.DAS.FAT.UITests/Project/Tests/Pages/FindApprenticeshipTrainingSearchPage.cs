using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FindApprenticeshipTrainingSearchPage : FATBasePage
    {
        protected override string PageTitle => "Find apprenticeship training";
        private readonly ScenarioContext _context;

        public FindApprenticeshipTrainingSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TrainingCourseSearchResultsPage SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(string searchTerm)
        {
            SearchApprenticeship(searchTerm);
            return new TrainingCourseSearchResultsPage(_context);
        }
    }
}
