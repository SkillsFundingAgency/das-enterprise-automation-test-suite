using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.MailosaurAPI.Service;

[Binding]
public class MailosaurAPIConfigurationSetup(ScenarioContext context)
{
    private const string MailosaurApiConfig = "MailasourApiConfig";

    [BeforeScenario(Order = 1)]
    public void SetUpMailosaurAPIConfiguration()
    {
        var mailosaurApiConfigs = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<MailosaurApiConfig>(MailosaurApiConfig);

        var mailosaurApiConfig = Configurator.IsAzureExecution ? mailosaurApiConfigs.Single(x => x.ServerName == "azure") : mailosaurApiConfigs.Single(x => x.ServerName == "local");

        context.Set(new MailosaurUser(mailosaurApiConfig.ServerName, mailosaurApiConfig.ServerId, mailosaurApiConfig.ApiToken));
    }
}
