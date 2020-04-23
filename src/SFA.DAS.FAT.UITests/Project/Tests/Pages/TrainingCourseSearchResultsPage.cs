using OpenQA.Selenium;
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

        private void ClickLevelCheckBox(string level) => formCompletionHelper.Click(LevelCheckBox(level));
    }
}
