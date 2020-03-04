using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerRealStoriesPage : EmployerBasePage
    {
        protected override string PageTitle => "REAL STORIES";

        private string ExpectedPageDescription => "Have you ever thought about hiring an apprentice? Have a look at real stories from other employers, and see how taking on an apprentice can benefit your organisation.";

        private By PageDescription => By.ClassName("lead-paragraph");

        public EmployerRealStoriesPage(ScenarioContext context) : base(context) => pageInteractionHelper.VerifyText(PageDescription, ExpectedPageDescription);
    }
}
