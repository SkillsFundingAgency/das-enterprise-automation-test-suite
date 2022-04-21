using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 30)]
        public void SetUpHelpers()
        {
            _context.Set(new CampaignsDataHelper());

            _context.Get<TabHelper>().GoToUrl(UrlConfig.CA_BaseUrl);
        }
    }
}