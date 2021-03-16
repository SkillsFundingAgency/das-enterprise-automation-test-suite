using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EIConfig _eIConfig;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _eIConfig = context.GetEIConfig<EIConfig>();
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new EISqlHelper(_eIConfig));
    }
}
