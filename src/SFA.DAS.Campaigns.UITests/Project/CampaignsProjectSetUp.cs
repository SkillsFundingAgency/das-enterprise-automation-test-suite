using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project
{
    [Binding]
    public class CampaignsProjectSetUp
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public CampaignsProjectSetUp(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<CampaignsConfig>();
            _context.SetCampaignsConfig(config);

            var user = _configSection.GetConfigSection<CampaingnsEmployerUser>();
            _context.SetUser(user);
        }
    }
}
