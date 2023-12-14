using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class GetStartedWithRecruitmentAPIsPage : Raav2BasePage
    {
        protected override string PageTitle => "Get started with the recruitment APIs";

        private readonly By APIKeysHereLink = By.LinkText("API keys here");

        public GetStartedWithRecruitmentAPIsPage(ScenarioContext context) : base(context) { }

        public ApiListPage ClickAPIKeysHereLink()
        {
            formCompletionHelper.Click(APIKeysHereLink);
            return new ApiListPage(context);
        }
    }
}