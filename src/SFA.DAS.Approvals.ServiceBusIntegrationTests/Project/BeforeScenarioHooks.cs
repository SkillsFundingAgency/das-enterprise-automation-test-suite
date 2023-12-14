using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework;
using SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => context.Set(new PublishPaymentEvent(new NServiceBusHelper(context.Get<FrameworkConfig>().NServiceBusConfig.ServiceBusConnectionString)));
    }
}