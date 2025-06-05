using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
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
            context.SetApprenticeAccountsPortalUser([_configSection.GetConfigSection<ApprenticeAppUser>()]);
        }
    }
}
