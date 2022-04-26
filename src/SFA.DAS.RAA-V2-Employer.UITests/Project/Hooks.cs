using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 34)]
        public void SetUpHelpers() => _context.Set(new ProviderPermissionsSqlDbHelper(_context.Get<DbConfig>()));
    }
}
