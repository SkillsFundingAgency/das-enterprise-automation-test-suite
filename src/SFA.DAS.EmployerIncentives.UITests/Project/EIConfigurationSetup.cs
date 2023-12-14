using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class EIConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpEIConfigConfiguration()
        {

            var config = _configSection.GetConfigSection<EIConfig>();

            context.SetEIConfig(config);

            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<EINoApplicationUser>(),
                _configSection.GetConfigSection<EIWithdrawLevyUser>(),
                _configSection.GetConfigSection<EIAddVrfUser>(),
                _configSection.GetConfigSection<EIAmendVrfUser>()
            ]);
        }
    }
}
