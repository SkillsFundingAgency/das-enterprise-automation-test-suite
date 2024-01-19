using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class RAAV2EmployerConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpRAAV2EmployerProjectConfiguration()
        {
            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<RAAV2EmployerUser>(),

                _configSection.GetConfigSection<RAAV2EmployerProviderPermissionUser>()
            ]);
        }
    }
}
