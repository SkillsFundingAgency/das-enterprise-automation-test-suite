using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        
        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            _context.Set(new EISqlHelper(_context.Get<DbConfig>()));
            _context.Set(new StopWatchHelper());
            _context.Set(new CollectionPeriodHelper(_context));            
            _context.Set(new EIPaymentsProcessHelper(_context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>()));
            _context.Set(new PaymentsOrchestratorHelper(_context));
            
        }
    }
}
