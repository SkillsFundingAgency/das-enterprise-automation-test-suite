using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 34)]
        public void SetUpHelpers()
        {
            _context.Set(new ProviderPermissionsSqlDbHelper(_context.Get<ObjectContext>(), _context.Get<DbConfig>()));

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(new RandomCourseDataHelper(), ApprenticeStatus.WaitingToStart);

            _context.Set(apprenticeCourseDataHelper);
        }
    }
}
