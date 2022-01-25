using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        
        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => _context.Set(new EmploymentChecksSqlDbHelper(_context.Get<DbConfig>()));
    }
}
