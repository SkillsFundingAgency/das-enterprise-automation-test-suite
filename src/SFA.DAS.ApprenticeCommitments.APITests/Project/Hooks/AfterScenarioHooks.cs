using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Hooks
{
    [Binding, Scope(Tag = "deletecmaddatacreatedthroughapi")]
    public class AfterScenarioHooks
    {
        protected readonly ObjectContext _objectContext;
        protected readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _aLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsAccountsSqlDbHelper _apprenticeCommitmentsAccountsSqlDbHelper;
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _aLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsAccountsSqlDbHelper = context.Get<ApprenticeCommitmentsAccountsSqlDbHelper>();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
        }

        [AfterScenario(Order = 33)]
        public void ClearDownUserData()
        {
            var email = _objectContext.GetApprenticeEmail();
            var apprenticeshipId = _objectContext.GetCommitmentsApprenticeshipId();
            var apprenticeId = _aLoginSqlDbHelper.GetApprenticeIdFromAspNetUsersTable(email);

            //appacc db
            _apprenticeCommitmentsAccountsSqlDbHelper.DeleteEmailAddressHistoryTableData(apprenticeId);
            _apprenticeCommitmentsAccountsSqlDbHelper.DeleteApprenticeTableData(apprenticeId);

            //acomt db
            _aComtSqlDbHelper.DeleteRevisionAndApprenticeshipTableData(apprenticeId, email); 
            _aComtSqlDbHelper.DeleteRegistrationTableData(email); 

            //alogin db
            _aLoginSqlDbHelper.DeleteAspNetUsersTableDataForCMAD(apprenticeId);
            _aLoginSqlDbHelper.DeleteResetPasswordRequestsTableData(email);
            _aLoginSqlDbHelper.DeleteUserLogsTableData(email);

            //Commitments db
            _accountsAndCommitmentsSqlHelper.ResetEmailForApprenticeshipRecord(long.Parse(apprenticeshipId));
        }
    }
}
