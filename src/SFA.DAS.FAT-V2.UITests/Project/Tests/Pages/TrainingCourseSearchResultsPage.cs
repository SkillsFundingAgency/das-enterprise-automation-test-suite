using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    class TrainingCourseSearchResultsPage : FATV2BasePage
    {
        protected override string PageTitle => "Apprenticeship training courses";
        private readonly ScenarioContext _context;

        #region Locators
        private By UpdateResultsButton => By.Id("filters-submit");
        private By LevelCheckBox(string level) => By.Id($"level-{level}");
        private By LevelText => By.ClassName("das-no-wrap");
        #endregion

        public TrainingCourseSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public TrainingCourseSearchResultsPage SelectLevelAndFilterResults(string level)
        {
            SelectLevelCheckBox(level);
            formCompletionHelper.Click(UpdateResultsButton);
            return this;
        }
        public TrainingCourseSearchResultsPage VerifyLevelInfoFromSearchResults(string level)
        {
            pageInteractionHelper.VerifyText(LevelText, level);
            UnselectLevelCheckBox(level);
            formCompletionHelper.Click(UpdateResultsButton);
            return this;
        }
        private void SelectLevelCheckBox(string level) => formCompletionHelper.SelectCheckbox(LevelCheckBox(level));
        private void UnselectLevelCheckBox(string level) => formCompletionHelper.UnSelectCheckbox(LevelCheckBox(level));
    }
}
