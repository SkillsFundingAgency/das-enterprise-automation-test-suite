using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class GetStartedWithRecruitmentAPIsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Get started with the recruitment APIs";

        private readonly By APIKeysHereLink = By.LinkText("API keys here");
        private readonly By DeveloperGetStartedPageLink = By.LinkText("developer get started page");

        public ApiListPage ClickAPIKeysHereLink()
        {
            formCompletionHelper.Click(APIKeysHereLink);
            return new ApiListPage(context);
        }

        public ApprenticeshipServiceDevHubPage ClickDeveloperGetStartedPageLink()
        {
            formCompletionHelper.Click(DeveloperGetStartedPageLink);
            return new ApprenticeshipServiceDevHubPage(context);
        }
    }
}