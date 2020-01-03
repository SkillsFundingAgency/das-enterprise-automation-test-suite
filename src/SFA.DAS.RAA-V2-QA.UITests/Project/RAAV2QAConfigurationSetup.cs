using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project
{
    [Binding]
    public class RAAV2QAConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public RAAV2QAConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration()
        {
            var config = _configSection.GetConfigSection<RAAV2QAConfig>();
            _context.SetRAAV2QAConfig(config);
        }
    }
}
