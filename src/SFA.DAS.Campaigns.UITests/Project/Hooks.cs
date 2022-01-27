using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
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

            _context.GetWebDriver().Navigate().GoToUrl(UrlConfig.CA_BaseUrl);
        }
    }
}