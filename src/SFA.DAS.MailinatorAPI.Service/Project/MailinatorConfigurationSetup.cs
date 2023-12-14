using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project;

[Binding]
public class MailinatorConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpMailinatorConfiguration() => context.Set(context.Get<IConfigSection>().GetConfigSection<MailinatorConfig>());
}
