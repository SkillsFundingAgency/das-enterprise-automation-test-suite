using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project;

[Binding]
public class MailinatorConfigurationSetup
{
    private readonly ScenarioContext _context;

    public MailinatorConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpMailinatorConfiguration() => _context.Set(_context.Get<IConfigSection>().GetConfigSection<MailinatorConfig>());
}
