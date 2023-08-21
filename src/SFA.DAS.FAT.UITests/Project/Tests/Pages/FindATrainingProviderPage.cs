using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FindATrainingProviderPage : FATBasePage
    {
        protected override string PageTitle => "Find a training provider";

        public FindATrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        #region Locators
        private static By PostCodeTextBox => By.Id("search-box");
        protected override By SearchButton => By.CssSelector(".button.Postcode-search-button");
        #endregion

        public ProviderSearchResultsPage EnterPostCodeAndSearch(string postCode)
        {
            formCompletionHelper.EnterText(PostCodeTextBox, postCode);
            formCompletionHelper.Click(SearchButton);
            return new ProviderSearchResultsPage(context);
        }

        public TrainingCourseSummaryPage NavigateBackFromFindATrainingProviderPage()
        {
            NavigateBack();
            return new TrainingCourseSummaryPage(context);
        }
    }
}
