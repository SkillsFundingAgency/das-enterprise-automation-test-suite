using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FindATrainingProviderPage : FATBasePage
    {
        protected override string PageTitle => "Find a training provider";
        private readonly ScenarioContext _context;

        public FindATrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        #region Locators
        private By PostCodeTextBox => By.Id("search-box");
        protected override By SearchButton => By.CssSelector(".button.postcode-search-button");
        #endregion

        public ProviderSearchResultsPage EnterPostCodeAndSearch(string postCode)
        {
            formCompletionHelper.EnterText(PostCodeTextBox, postCode);
            formCompletionHelper.Click(SearchButton);
            return new ProviderSearchResultsPage(_context);
        }

        public TrainingCourseSummaryPage NavigateBackFromFindATrainingProviderPage()
        {
            NavigateBack();
            return new TrainingCourseSummaryPage(_context);
        }
    }
}
