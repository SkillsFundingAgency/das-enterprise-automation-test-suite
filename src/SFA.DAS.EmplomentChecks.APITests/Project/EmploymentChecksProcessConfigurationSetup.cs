using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public class EmploymentChecksProcessConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public EmploymentChecksProcessConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEmploymentChecksConfigConfiguration() => _context.SetEIPaymentProcessConfig(_configSection.GetConfigSection<EmploymentChecksProcessConfig>());
    }
}
