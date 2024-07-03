using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup(ScenarioContext context)
    {
        [BeforeScenario(Order = 0)]
        public void SetUpConfiguration()
        {
            var configSection = new ConfigSection(Configurator.GetConfig());

            context.Set(configSection);

            var dbConfig = configSection.GetConfigSection<DbConfig>();

            if (!Configurator.IsAdoExecution) dbConfig = new LocalHostDbConfig(configSection.GetConfigSection<DbDevConfig>(), context.ScenarioInfo.Tags.Contains("usesqllogin")).GetLocalHostDbConfig();

            context.Set(dbConfig);
        }
    }
}