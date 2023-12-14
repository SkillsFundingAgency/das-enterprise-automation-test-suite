using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Hooks
{
    [Binding]
    public class ApprenticeCommitmentsConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpRegistrationConfigConfiguration()
        {
            context.SetApprenticeCommitmentsConfig(_configSection.GetConfigSection<ApprenticeCommitmentsConfig>());

            var cocEmpUser = _configSection.GetConfigSection<ASCoCEmployerUser>();

            cocEmpUser.CocApprenticeUser = _configSection.GetConfigSection<CocApprenticeUser>();

            context.SetEasLoginUser([cocEmpUser, _configSection.GetConfigSection<ASListedLevyUser>()]);
        }
    }
}
