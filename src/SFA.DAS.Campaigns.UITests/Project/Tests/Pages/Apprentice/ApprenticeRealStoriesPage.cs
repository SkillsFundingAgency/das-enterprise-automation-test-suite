using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeRealStoriesPage : ApprenticeBasePage
    {
        protected override string PageTitle => "REAL STORIES";

        private string ExpectedPageDescription => "Read some real stories to find out how becoming an apprentice can change your life.";
        private By PageDescription => By.ClassName("lead-paragraph");

        public ApprenticeRealStoriesPage(ScenarioContext context) : base(context) => pageInteractionHelper.VerifyText(PageDescription, ExpectedPageDescription);
    }
}
