using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class TrainingCourseSearchResultsPage : FATBasePage
    {
        protected override string PageTitle => "Search results";
        private readonly ScenarioContext _context;

        #region Locators
        private By FilterResultsPanel => By.CssSelector(".filters.filters-accordion");
        private By LevelCheckBox(string level) => By.Id($"SelectedLevels_{level}");
        private By SortByDropDownField => By.Id("select-order");
        private By LevelText => By.CssSelector("dd.level");
        private By UpdateResultsButton => By.CssSelector(".button[value='Update results']");
        private By FirstResultLink => By.CssSelector("h2.result-title");
        private By SortByDropDown => By.Id("select-order");
        private By LevelInfoText => By.ClassName("level");
        #endregion

        public TrainingCourseSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TrainingCourseSearchResultsPage VerifyFilterAndSortByFields()
        {
            VerifyPage(FilterResultsPanel);
            VerifyPage(SortByDropDownField);
            return this;
        }

        public TrainingCourseSearchResultsPage SearchApprenticeshipInSearchResultsPage(string searchTerm)
        {
            SearchApprenticeship(searchTerm);
            return this;
        }

        public TrainingCourseSearchResultsPage SelectLevelAndFilterResults(string level)
        {
            ClickLevelCheckBox(level);
            formCompletionHelper.Click(UpdateResultsButton);
            return this;
        }

        public TrainingCourseSearchResultsPage VerifyLevelInfoFromSearchResults(string level)
        {
            pageInteractionHelper.VerifyText(LevelText, level);
            ClickLevelCheckBox(level);
            return this;
        }

        public TrainingCourseSummaryPage SelectFirstTrainingResult()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetTrainingCourseName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new TrainingCourseSummaryPage(_context);
        }

        public void SelectAscendingOrderSort() => SelectDropDownValue("Level (low to high)");

        public void SelectDescendingOrderSort() => SelectDropDownValue("Level (high to low)");

        public IEnumerable<string> GetLevelInfoFromResults() => pageInteractionHelper.GetStringCollectionFromElementsGroup(LevelInfoText);

        private void ClickLevelCheckBox(string level) => formCompletionHelper.Click(LevelCheckBox(level));

        private void SelectDropDownValue(string value) => formCompletionHelper.SelectFromDropDownByText(SortByDropDown, value);
    }
}
