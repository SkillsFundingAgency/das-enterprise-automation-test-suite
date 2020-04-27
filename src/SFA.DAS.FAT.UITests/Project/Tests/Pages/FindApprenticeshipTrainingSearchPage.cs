using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FindApprenticeshipTrainingSearchPage : FATBasePage
    {
        protected override string PageTitle => "Find apprenticeship training";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchTrainingProviderLink => By.CssSelector("span[id='search-training-provider'] a");
        #endregion

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

        public FATIndexPage NavigateBackFromFindApprenticeshipTrainingSearchPage()
        {
            NavigateBack();
            return new FATIndexPage(_context);
        }

        public FindATrainingProviderByNamePage ClickSearchTrainingProviderLink()
        {
            formCompletionHelper.Click(SearchTrainingProviderLink);
            return new FindATrainingProviderByNamePage(_context);
        }
    }
}
