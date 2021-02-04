using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.API.Framework
{
    [Binding]
    public class ApiFrameworkConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ApiFrameworkConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpApiFrameworkConfiguration() => _context.Set(_configSection.GetConfigSection<ApiFrameworkConfig>());
    }
}