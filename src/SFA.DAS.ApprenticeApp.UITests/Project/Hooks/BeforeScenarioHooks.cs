using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Hooks
{
        [Binding]
        public class BeforeScenarioHooks(ScenarioContext context)
        {
            private readonly ConfigSection _configSection = context.Get<ConfigSection>();
            [BeforeScenario(Order = 2)]
            public void AppSetupHelpers()
            {
                context.SetApprenticeAppConfig(_configSection.GetConfigSection<ApprenticeAppConfig>());
            }
        }
}
