using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class GetStartedWithRecruitmentAPIsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Get started with the recruitment APIs";

        protected override bool TakeFullScreenShot => false;

        private readonly By APIKeysHereLink = By.LinkText("API keys here");

        public GetStartedWithRecruitmentAPIsPage(ScenarioContext context) : base(context) { }

        public APIListPage ClickAPIKeysHereLink()
        {
            formCompletionHelper.Click(APIKeysHereLink);
            return new APIListPage(context);
        }
    }
}