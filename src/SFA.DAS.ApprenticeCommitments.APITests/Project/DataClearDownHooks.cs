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
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;

        public DataClearDownHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _aLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
        }

        public void ClearDownUser()
        {
            var email = _objectContext.GetApprenticeEmail();
            var apprenticeshipid = _objectContext.GetApprenticeId();

            //acomt db
            _aComtSqlDbHelper.DeleteApprentice(email);
            _aComtSqlDbHelper.DeleteApprentice(_apprenticeCommitmentsDataHelper.NewEmail);

            //alogin db
            _aLoginSqlDbHelper.DeleteUser(email);
            _aLoginSqlDbHelper.DeleteResetPasswordRequests(email);
            _aLoginSqlDbHelper.DeleteUserLogs(email);

            //Commitments db
            _accountsAndCommitmentsSqlHelper.ResetEmailForApprenticeshipRecord(long.Parse(apprenticeshipid));
        }
    }
}
