using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    class TrainingCourseSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetTrainingCourseName();
        private readonly ScenarioContext _context;

        #region Locators
        private By LocationTextBox => By.Id("search-location");
        private By ViewProvidersForThisCourseButton => By.Id("btn-view-providers");
        #endregion

        public TrainingCourseSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
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

    }
}
