using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CovidRedundancy.UITests.Project
{
    public class CRConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public CRConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpCRConfiguration()
        {
            var config = _configSection.GetConfigSection<CRConfig>();
            _context.SetCRConfig(config);
        }
    }
}
