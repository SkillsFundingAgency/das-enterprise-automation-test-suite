using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class TrainingCourseSummaryPage : FATBasePage
    {
        protected override string PageTitle => objectContext.GetTrainingCourseName();
        private readonly ScenarioContext _context;

        #region Locators
        private By FindTrainingProvidersButton => By.LinkText("Find training providers");
        #endregion

        public TrainingCourseSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FindATrainingProviderPage ClickFindTrainingProvidersButton()
        {
            formCompletionHelper.Click(FindTrainingProvidersButton);
            return new FindATrainingProviderPage(_context);
        }

        public TrainingCourseSearchResultsPage NavigateBackFromTrainingCourseSummaryPage()
        {
            NavigateBack();
            return new TrainingCourseSearchResultsPage(_context);
        }
    }
}
