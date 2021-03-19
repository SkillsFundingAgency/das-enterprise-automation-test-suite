using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EIConfig _eIConfig;
        private readonly FrameworkConfig _config;
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _eIConfig = context.GetEIConfig<EIConfig>();
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            _context.Set(new EISqlHelper(_eIConfig));
            _context.Set(new NServiceBusHelper(_config.NServiceBusConfig.ServiceBusConnectionString));
        }
    }
}
