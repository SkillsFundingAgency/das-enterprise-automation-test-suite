using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service;

[Binding]
public class MailosaurAPIConfigurationSetup(ScenarioContext context)
{
    private const string MailosaurApiConfig = "MailasourApiConfig";

    [BeforeScenario(Order = 1)]
    public void SetUpMailosaurAPIConfiguration() => new MultiConfigurationSetupHelper(context).SetMultiConfiguration<MailosaurApiUser>(MailosaurApiConfig);
}
