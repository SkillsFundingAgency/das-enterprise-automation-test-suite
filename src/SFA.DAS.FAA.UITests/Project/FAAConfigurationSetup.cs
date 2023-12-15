using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project
{
    [Binding]
    public class FAAConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration() => context.SetFAAConfig(_configSection.GetConfigSection<FAAConfig>());
    }
}
