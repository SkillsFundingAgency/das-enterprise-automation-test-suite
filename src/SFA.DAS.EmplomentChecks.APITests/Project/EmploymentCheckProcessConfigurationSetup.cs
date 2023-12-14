using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project;

[Binding]
public class EmploymentCheckProcessConfigurationSetup(ScenarioContext context)
{
    private readonly ScenarioContext _context = context;
    private readonly IConfigSection _configSection = context.Get<IConfigSection>();

    [BeforeScenario(Order = 2)]
    public void SetUpEmploymentCheckProcessConfig() => _context.SetEmploymentCheckPaymentProcessConfig(_configSection.GetConfigSection<EmploymentCheckProcessConfig>());
}
