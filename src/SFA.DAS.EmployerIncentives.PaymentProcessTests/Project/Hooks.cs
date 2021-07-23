using AutoFixture;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly Fixture _fixture;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _fixture = new Fixture();
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            _context.Set(_fixture.Create<TestData>());
            _context.Set(new EISqlHelper(_context.Get<DbConfig>()));
            _context.Set(new StopWatchHelper());
            _context.Set(new CollectionPeriodHelper(_context));

            var eiConfig = _context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            _context.Set(new EIPaymentsProcessHelper(eiConfig));
            _context.Set(new EILearnerMatchHelper(eiConfig));
            _context.Set(new PaymentsOrchestratorHelper(_context));
            _context.Set(new LearnerMatchOrchestratorHelper(_context));
            _context.Set(new EIServiceBusHelper(eiConfig));
            _context.Set(new IncentiveApplicationHelper(_context));            
        }
    }
}
