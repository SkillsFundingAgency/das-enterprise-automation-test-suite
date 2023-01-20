using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Hooks
{
    [Binding]
    public class EmployerAccountsApiConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public EmployerAccountsApiConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEmployerAccountsApiConfig() => _context.SetEmployerAccountsApiConfig(_configSection.GetConfigSection<EmployerAccountsApiConfig>());
    }
}
