using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    class TrainingCourseSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetTrainingCourseName();
        private readonly ScenarioContext _context;

        #region Locators
        private By PostCodeTextBox => By.Id("search-location");
        private By ViewProvidersForThisCourseButton => By.TagName("button");
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
        public ProviderSearchResultsPage EnterPostCodeAndSearch(string postCode)
        {
            formCompletionHelper.EnterText(PostCodeTextBox, postCode);
            formCompletionHelper.SendKeys(PostCodeTextBox, Keys.Tab);
            formCompletionHelper.Click(ViewProvidersForThisCourseButton);
            return new ProviderSearchResultsPage(_context);
        }

    }
}
