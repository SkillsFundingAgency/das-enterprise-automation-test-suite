using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    [Binding]
    public class RAAV1ConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public RAAV1ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration()
        {
            var config = _configSection.GetConfigSection<RAAV1Config>();
            _context.SetRAAV1Config(config);
        }
    }
}
