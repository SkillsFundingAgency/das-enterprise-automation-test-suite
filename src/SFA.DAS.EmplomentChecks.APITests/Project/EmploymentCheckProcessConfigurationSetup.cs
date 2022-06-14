using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public class EmploymentCheckProcessConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public EmploymentCheckProcessConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEmploymentCheckProcessConfig() => _context.SetEmploymentCheckPaymentProcessConfig(_configSection.GetConfigSection<EmploymentCheckProcessConfig>());
    }
}
