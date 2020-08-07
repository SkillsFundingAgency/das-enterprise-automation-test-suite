using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerRealStoriesPage : EmployerBasePage
    {
        protected override string PageTitle => "REAL STORIES";

        private string ExpectedPageDescription => "Read some real stories from employers about the benefits of hiring an apprentice.";

        private By PageDescription => By.ClassName("lead-paragraph");

        public EmployerRealStoriesPage(ScenarioContext context) : base(context) => pageInteractionHelper.VerifyText(PageDescription, ExpectedPageDescription);
    }
}
