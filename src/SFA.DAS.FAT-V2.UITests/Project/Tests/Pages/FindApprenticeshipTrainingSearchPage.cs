using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    class FindApprenticeshipTrainingSearchPage : FATV2BasePage
    {
        protected override string PageTitle => "Apprenticeship training courses";
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
