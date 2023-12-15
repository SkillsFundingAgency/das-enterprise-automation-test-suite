using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding]
    public class ConsolidatedSupportConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpConsolidatedSupportProjectConfiguration()
        {
            context.SetConsolidatedSupportConfig(_configSection.GetConfigSection<ConsolidatedSupportConfig>());
        }
    }
}