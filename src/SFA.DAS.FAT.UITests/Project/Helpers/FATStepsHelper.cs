using NUnit.Framework;
using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Helpers
{
    public class FATStepsHelper
    {
        private readonly ScenarioContext _context;
        
        public FATStepsHelper(ScenarioContext context) => _context = context;

        public TrainingCourseSearchResultsPage SearchForTrainingCourse(string course = "")
        {
            new FATIndexPage(_context).ClickStartButton().SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(course);
            return new TrainingCourseSearchResultsPage(_context);
        }

        public void CheckIfSatisfactionAndAchievementRatesAreDisplayed(ProviderSearchResultsPage providerSearchResultsPage)
        {
            Assert.IsTrue(RegexHelper.CheckForPercentageValueMatch(providerSearchResultsPage.GetEmployerSatisfactionPercentageInfo()), "EmployerSatisfactionPercentageInfo is Not displayed");
            Assert.IsTrue(RegexHelper.CheckForPercentageValueMatch(providerSearchResultsPage.GetLearnerSatisfactionPercentageInfoInfo()), "LearnerSatisfactionPercentageInfo is Not displayed");

            var achievementRatePercentageInfo = providerSearchResultsPage.GetAchievementRatePercentageInfoInfo();

            if (!RegexHelper.CheckForPercentageValueMatch(achievementRatePercentageInfo))
                Assert.AreEqual("no data available", achievementRatePercentageInfo, "AchievementRateInfo is Not displayed");
        }
    }
}
