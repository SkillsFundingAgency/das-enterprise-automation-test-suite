using Microsoft.Extensions.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigurationRoot _configurationRoot;

        private readonly ConfigSection _configSection;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configurationRoot = Configurator.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);
        }

        [BeforeScenario(Order = 0)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var dbConfig = new LocalHostDbConfig(_configSection.GetConfigSection<DbConfigusingMI>(), _context.ScenarioInfo.Tags.Contains("usesqllogin")).GetLocalHostDbConfig();

            _context.Set(dbConfig);
        }
    }
}