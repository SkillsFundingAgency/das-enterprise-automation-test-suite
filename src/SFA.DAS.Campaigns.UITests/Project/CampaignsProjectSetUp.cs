using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
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
            _context.SetCampaingnsProjectConfig(config);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            var WebDriver = _context.GetWebDriver();
            _context.Set(new PageInteractionCampaignsHelper(WebDriver));
        }

    }
}
