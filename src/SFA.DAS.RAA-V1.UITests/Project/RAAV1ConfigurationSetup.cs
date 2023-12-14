using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    [Binding]
    public class RAAV1ConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration() => context.SetRAAV1Config(_configSection.GetConfigSection<RAAV1Config>());
    }
}
