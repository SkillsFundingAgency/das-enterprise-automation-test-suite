using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;
        private readonly EIPaymentProcessConfig _eIPaymentProcessConfig;
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _eIPaymentProcessConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            _context.Set(new EISqlHelper(_dbConfig));
            _context.Set(new NServiceBusHelper(_eIPaymentProcessConfig.EI_ServiceBusConnectionString));
        }
    }
}
