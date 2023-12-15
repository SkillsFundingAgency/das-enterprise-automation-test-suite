using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Hooks
{
    [Binding]
    public class EmployerAccountsApiConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpEmployerAccountsApiConfig() => context.SetEmployerAccountsApiConfig(_configSection.GetConfigSection<EmployerAccountsApiConfig>());
    }
}
