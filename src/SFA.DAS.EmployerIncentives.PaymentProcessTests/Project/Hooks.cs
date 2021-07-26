using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly Fixture _fixture;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _fixture = new Fixture();
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            _context.Set(_fixture.Create<TestData>());
            _context.Set(new Helper(_context));                       
        }
    }
}
