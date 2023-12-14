using SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => context.Set(new PublishPaymentEvent(new NServiceBusHelper(context.Get<FrameworkConfig>().NServiceBusConfig.ServiceBusConnectionString)));
    }
}