using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class FindATrainingProviderByNamePage : FATBasePage
    {
        protected override string PageTitle => "Find a training provider by name";
        
        #region Locators
        protected override By FirstResultLink => By.CssSelector("#provider-search-results a");
        private static By SearchTextBox => By.Id("searchTerm");
        private static By SearchOption => By.Id("submit-keywords");
        #endregion

        public FindATrainingProviderByNamePage(ScenarioContext context) : base(context) => VerifyPage();

        public FindATrainingProviderByNamePage SearchForProvider(string providerName)
        {
            formCompletionHelper.EnterText(SearchTextBox, providerName);
            formCompletionHelper.Click(SearchOption);
            return this;
        }

        public FindATrainingProviderByNamePage NavigateBackFromSearchResultsInFindATrainingProviderByNamePage()
        {
            NavigateBack();
            return this;
        }

        public FindApprenticeshipTrainingSearchPage NavigateBackFromFindATrainingProviderByNamePage()
        {
            NavigateBack();
            return new FindApprenticeshipTrainingSearchPage(context);
        }
    }
}
