using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigurationRoot _configurationRoot;

        private readonly IConfigSection _configSection;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configurationRoot = Configurator.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);
        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var dbConfig = _configSection.GetConfigSection<DbConfig>();

            _context.Set(dbConfig);
        }
    }
}