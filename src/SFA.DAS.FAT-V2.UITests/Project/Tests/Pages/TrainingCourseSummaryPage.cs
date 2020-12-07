using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class TrainingCourseSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetTrainingCourseName();
        private readonly ScenarioContext _context;

        #region Locators
        private By LocationTextBox => By.Id("search-location");
        private By ViewProvidersForThisCourseButton => By.Id("btn-view-providers");
        private By BackToCourseSearchPage => By.Id("courses-breadcrumb");

        #endregion

        public TrainingCourseSummaryPage(ScenarioContext context) : base(context) => _context = context;

        public FATV2IndexPage NavigateBackToHompage()
        {
            NavigateToHomepage();
            return new FATV2IndexPage(_context);
        }
        public ProviderSearchResultsPage EnterPostCodeAndSearch(string location)
        {
            formCompletionHelper.EnterText(LocationTextBox, location);
            formCompletionHelper.SendKeys(LocationTextBox, Keys.Tab);
            formCompletionHelper.Click(ViewProvidersForThisCourseButton);
            return new ProviderSearchResultsPage(_context);
        }
        public ProviderSearchResultsPage ClickViewProvidersForThisCourse()
        {
            formCompletionHelper.Click(ViewProvidersForThisCourseButton);
            return new ProviderSearchResultsPage(_context);
        }
        public TrainingCourseSearchResultsPage NavigateBackFromCourseSummaryPage()
        {
            NavigateBackToCourseSummary();
            return new TrainingCourseSearchResultsPage(_context);
        }
        public TrainingCourseSearchResultsPage NavigateBackToCourseSummary()
        {
            formCompletionHelper.Click(BackToCourseSearchPage);
            return new TrainingCourseSearchResultsPage(_context);
        }

    }
}
