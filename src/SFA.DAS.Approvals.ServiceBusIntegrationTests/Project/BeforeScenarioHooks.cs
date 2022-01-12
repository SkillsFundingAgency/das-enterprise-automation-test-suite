using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework;
using SFA.DAS.Approvals.ServiceBusIntegrationTests.Project.Helpers.NServiceBusHelpers;

namespace SFA.DAS.Approvals.ServiceBusIntegrationTests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new PublishPaymentEvent(new NServiceBusHelper(_context.Get<FrameworkConfig>().NServiceBusConfig.ServiceBusConnectionString)));
    }
}