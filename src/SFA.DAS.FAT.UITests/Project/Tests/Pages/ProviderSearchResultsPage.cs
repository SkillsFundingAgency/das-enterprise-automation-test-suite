using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class ProviderSearchResultsPage : FATBasePage
    {
        protected override string PageTitle => "Search results";
        private readonly ScenarioContext _context;

        public ProviderSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        #region Locators
        private By EmployerSatisfactionPercentageInfo => By.CssSelector("dd.employer-satisfaction");
        private By LearnerSatisfactionPercentageInfo => By.CssSelector("dd.learner-satisfaction");
        private By AchievementRatePercentageInfo => By.CssSelector("dd.achievement-rate");
        #endregion

        public string GetEmployerSatisfactionPercentageInfo() => pageInteractionHelper.GetText(EmployerSatisfactionPercentageInfo);

        public string GetLearnerSatisfactionPercentageInfoInfo() => pageInteractionHelper.GetText(LearnerSatisfactionPercentageInfo);

        public string GetAchievementRatePercentageInfoInfo() => pageInteractionHelper.GetText(AchievementRatePercentageInfo);

        public ProviderSummaryPage SelectFirstProviderResult()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetProviderName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new ProviderSummaryPage(_context);
        }

        public FindATrainingProviderPage NavigateBackFromProviderSearchResultsPage()
        {
            NavigateBack();
            return new FindATrainingProviderPage(_context);
        }
    }
}
