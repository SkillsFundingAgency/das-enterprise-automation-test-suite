using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project
{
    [Binding]
    public class ApprenticeRedundancyConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ApprenticeRedundancyConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpApprenticeRedundancyConfiguration()
        {
            var config = _configSection.GetConfigSection<ApprenticeRedundancyConfig>();
            _context.SetARConfig(config);
        }
    }
}
