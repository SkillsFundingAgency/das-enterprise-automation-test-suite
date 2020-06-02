using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    [Binding]
    public class ProviderFeedbackConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ProviderFeedbackConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProviderFeedbackConfiguration()
        {
            var config = _configSection.GetConfigSection<ProviderFeedbackConfig>();
            _context.SetProviderFeedbackConfig(config);
        }
    }
}
