using SFA.DAS.API.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => _context.SetRestClient(new Inner_CoursesApiRestClient(_context.GetInner_CoursesApiAuthTokenConfig()));
    }
}