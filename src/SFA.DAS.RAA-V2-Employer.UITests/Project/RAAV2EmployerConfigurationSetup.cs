using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class RAAV2EmployerConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

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
