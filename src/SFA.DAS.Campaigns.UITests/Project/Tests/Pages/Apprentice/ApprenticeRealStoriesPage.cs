using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeRealStoriesPage : ApprenticeBasePage
    {
        protected override string PageTitle => "REAL STORIES";

        private string ExpectedPageDescription => "Do you want to earn while you learn and get hands-on experience? Have a look at real stories and see how becoming an apprentice changed the following lives.";

        private By PageDescription => By.ClassName("lead-paragraph");

        public ApprenticeRealStoriesPage(ScenarioContext context) : base(context, false) => pageInteractionHelper.VerifyText(PageDescription, ExpectedPageDescription);
    }
}
