using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public abstract class DeleteBaseHooks
    {
        protected readonly ObjectContext _objectContext;
        protected readonly ApprenticeCommitmentsSqlDbHelper _apprenticeCommitmentsRegistrationSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;

        public DeleteBaseHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _apprenticeCommitmentsRegistrationSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        public void ClearDownInvitation()
        {
            var email = _objectContext.GetApprenticeEmail();

            _apprenticeLoginSqlDbHelper.DeleteInvitation(email);

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteRegistration(email);

            _apprenticeLoginSqlDbHelper.DeleteUserLogs(email);
        }

        public void ClearDownUser()
        {
            ClearDownInvitation();

            var email = _objectContext.GetApprenticeEmail();

            _apprenticeLoginSqlDbHelper.DeleteUser(email);

            _apprenticeLoginSqlDbHelper.DeleteUserRequests(email);

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteApprentice(email);
        }
    }
}
