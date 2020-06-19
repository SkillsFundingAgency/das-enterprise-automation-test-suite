using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project
{
    [Binding]
    public class ARConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ARConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpARConfiguration()
        {
            var config = _configSection.GetConfigSection<ARConfig>();
            _context.SetARConfig(config);
        }
    }
}
