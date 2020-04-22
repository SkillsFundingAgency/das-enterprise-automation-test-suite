using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class SearchResultsPage : FATBasePage
    {
        protected override string PageTitle => "Search results";

        #region Locators
        private By FilterResultsPanel => By.CssSelector(".filters.filters-accordion");
        private By LevelCheckBox(string level) => By.Id($"SelectedLevels_{level}");
        private By SortByDropDownField => By.Id("select-order");
        private By LevelText => By.CssSelector("dd.level");
        private By UpdateResultsButton => By.CssSelector(".button[value='Update results']");
        #endregion

        public SearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchResultsPage VerifyFilterAndSortByFields()
        {
            VerifyPage(FilterResultsPanel);
            VerifyPage(SortByDropDownField);
            return this;
        }

        public SearchResultsPage SearchApprenticeshipInSearchResultsPage(string searchTerm)
        {
            SearchApprenticeship(searchTerm);
            return this;
        }

        public SearchResultsPage SelectLevelAndFilterResults(string level)
        {
            ClickLevelCheckBox(level);
            formCompletionHelper.Click(UpdateResultsButton);
            return this;
        }

        public SearchResultsPage VerifyLevelInfoFromSearchResults(string level)
        {
            pageInteractionHelper.VerifyText(LevelText, level);
            ClickLevelCheckBox(level);
            return this;
        }

        private void ClickLevelCheckBox(string level) => formCompletionHelper.Click(LevelCheckBox(level));
    }
}
