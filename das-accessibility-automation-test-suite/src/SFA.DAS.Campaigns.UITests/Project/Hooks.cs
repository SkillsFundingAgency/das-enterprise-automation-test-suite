using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 30)]
        public void SetUpHelpers()
        {
            context.Set(new CampaignsDataHelper());

            context.Get<TabHelper>().GoToUrl(UrlConfig.CA_BaseUrl);
        }
    }
}