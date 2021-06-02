using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public abstract class DataClearDownHooks
    {
        protected readonly ObjectContext _objectContext;
        protected readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _aLoginSqlDbHelper;
        protected readonly ApprenticeCommitmentsDataHelper _apprenticeCommitmentsDataHelper;

        public DataClearDownHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _aLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
        }

        public void ClearDownInvitationRecords()
        {
            var email = _objectContext.GetApprenticeEmail();

            _aLoginSqlDbHelper.DeleteInvitation(email);
            _aLoginSqlDbHelper.DeleteUserLogs(email);
        }

        public void ClearDownUser()
        {
            var email = _objectContext.GetApprenticeEmail();

            _aComtSqlDbHelper.DeleteApprentice(email);
            _aComtSqlDbHelper.DeleteApprentice(_apprenticeCommitmentsDataHelper.NewEmail);

            _aLoginSqlDbHelper.DeleteAspNetUsersTable(email);
            _aLoginSqlDbHelper.DeleteResetPasswordRequests(email);

            ClearDownInvitationRecords();
        }
    }
}
