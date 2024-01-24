using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class Helper
    {
        public EISqlHelper EISqlHelper => _context.Get<EISqlHelper>();
        public StopWatchHelper StopWatchHelper => _context.Get<StopWatchHelper>();
        public CollectionCalendarHelper CollectionCalendarHelper => _context.Get<CollectionCalendarHelper>();
        public EIPaymentsProcessHelper EIPaymentsProcessHelper => _context.Get<EIPaymentsProcessHelper>();
        public EILearnerMatchHelper EILearnerMatchHelper => _context.Get<EILearnerMatchHelper>();
        public PaymentsOrchestratorHelper PaymentsOrchestratorHelper => _context.Get<PaymentsOrchestratorHelper>();
        public LearnerMatchOrchestratorHelper LearnerMatchOrchestratorHelper => _context.Get<LearnerMatchOrchestratorHelper>();
        public EIServiceBusHelper EIServiceBusHelper => _context.Get<EIServiceBusHelper>();
        public IncentiveApplicationHelper IncentiveApplicationHelper => _context.Get<IncentiveApplicationHelper>();
        public IncentiveHelper IncentiveHelper => _context.Get<IncentiveHelper>();
        public BusinessCentralApiHelper BusinessCentralApiHelper => _context.Get<BusinessCentralApiHelper>();
        public LearnerMatchApiHelper LearnerMatchApiHelper => _context.Get<LearnerMatchApiHelper>();
        public LearnerDataHelper LearnerDataHelper => _context.Get<LearnerDataHelper>();
        public EIFunctionsHelper EIFunctionsHelper => _context.Get<EIFunctionsHelper>();
        public EmploymentCheckHelper EmploymentCheckHelper => _context.Get<EmploymentCheckHelper>();
        public EmploymentCheckApiHelper EmploymentCheckApiHelper => _context.Get<EmploymentCheckApiHelper>();

        private readonly ScenarioContext _context;

        public Helper(ScenarioContext context)
        {
            _context = context;
            context.Set(new EISqlHelper(context.Get<ObjectContext>(), context.Get<DbConfig>()));
            context.Set(IEDataSnapper.Create(context.Get<DbConfig>()));
            context.Set(new StopWatchHelper());
            context.Set(new CollectionCalendarHelper(context));

            var eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            context.Set(new EIPaymentsProcessHelper(eiConfig));
            context.Set(new EILearnerMatchHelper(eiConfig));
            context.Set(new PaymentsOrchestratorHelper(context));
            context.Set(new LearnerMatchOrchestratorHelper(context));
            context.Set(new EIServiceBusHelper(eiConfig));
            context.Set(new IncentiveApplicationHelper(context));
            context.Set(new IncentiveHelper(context));
            context.Set(new BusinessCentralApiHelper(context));
            context.Set(new LearnerMatchApiHelper(context));
            context.Set(new LearnerDataHelper(context));
            context.Set(new EIFunctionsHelper(eiConfig));
            context.Set(new EmploymentCheckHelper(context));
            context.Set(new EmploymentCheckApiHelper(context));
        }
    }
}
