using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class ApprovalsConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpApprovalsConfiguration()
        {
            if (NoNeedToSetUpConfiguration()) return;

            context.SetApprovalsConfig(_configSection.GetConfigSection<ApprovalsConfig>());

            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<ProviderPermissionLevyUser>(),
                _configSection.GetConfigSection<EmployerWithMultipleAccountsUser>(),
                _configSection.GetConfigSection<FlexiJobUser>(),
                _configSection.GetConfigSection<EmployerConnectedToPortableFlexiJobProvider>()
            ]);
        }

        private bool NoNeedToSetUpConfiguration()
        {
            if (context.ScenarioInfo.Tags.Contains("deletecohortviaemployerportal"))
            {
                context.SetEasLoginUser([_configSection.GetConfigSection<DeleteCohortLevyUser>()]);
            }

            return new TestDataSetUpConfigurationHelper(context).NoNeedToSetUpConfiguration();
        }
    }
}
