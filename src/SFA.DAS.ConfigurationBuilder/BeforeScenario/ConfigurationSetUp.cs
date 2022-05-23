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

            if (!Configurator.IsVstsExecution) dbConfig = new LocalHostDbConfig(_configSection.GetConfigSection<DbDevConfig>(), _context.ScenarioInfo.Tags.Contains("usesqllogin")).GetLocalHostDbConfig();

            _context.Set(dbConfig);
        }
    }
}