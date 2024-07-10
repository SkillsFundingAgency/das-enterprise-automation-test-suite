using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project
{
    [Binding]
    public class RAAEmployerConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpRAAEmployerProjectConfiguration()
        {
            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<RAAEmployerUser>(),

                _configSection.GetConfigSection<RAAEmployerProviderPermissionUser>()
            ]);
        }
    }
}
