using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding, Scope(Tag = "deleteinvitation")]
    public class CreateAccountHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeCommitmentsRegistrationSqlDbHelper _apprenticeCommitmentsRegistrationSqlDbHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;


        public CreateAccountHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _apprenticeCommitmentsRegistrationSqlDbHelper = context.Get<ApprenticeCommitmentsRegistrationSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        [AfterScenario(Order = 34)]
        public void ClearDownData()
        {
            var email = _objectContext.GetApprenticeEmail();

            _apprenticeLoginSqlDbHelper.DeleteInvitation(email);

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteRegistration(email);

            if (_context.ScenarioInfo.Tags.Contains("deleteuser"))
            {
                _apprenticeLoginSqlDbHelper.DeleteUser(email);
            }

            _apprenticeLoginSqlDbHelper.DeleteUserLogs(email);
        }
    }
}
