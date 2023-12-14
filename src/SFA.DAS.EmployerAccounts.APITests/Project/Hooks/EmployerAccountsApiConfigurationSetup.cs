using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Hooks
{
    [Binding]
    public class EmployerAccountsApiConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpEmployerAccountsApiConfig() => context.SetEmployerAccountsApiConfig(_configSection.GetConfigSection<EmployerAccountsApiConfig>());
    }
}
