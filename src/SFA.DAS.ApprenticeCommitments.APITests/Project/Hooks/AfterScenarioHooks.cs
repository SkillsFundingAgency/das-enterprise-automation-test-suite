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
            var apprenticeshipid = _objectContext.GetCommitmentsApprenticeshipId();

            _aComtSqlDbHelper.DeleteRevisionAndApprenticeshipTableData(email); //acomt db

            //appacc db
            _apprenticeCommitmentsAccountsSqlDbHelper.DeleteEmailAddressHistoryTableData(email);
            _apprenticeCommitmentsAccountsSqlDbHelper.DeleteApprenticeTableData(email);

            _aComtSqlDbHelper.DeleteRegistrationTableData(email); //acomt db

            //alogin db
            _aLoginSqlDbHelper.DeleteUser(email);
            _aLoginSqlDbHelper.DeleteResetPasswordRequests(email);
            _aLoginSqlDbHelper.DeleteUserLogs(email);

            //Commitments db
            _accountsAndCommitmentsSqlHelper.ResetEmailForApprenticeshipRecord(long.Parse(apprenticeshipid));
        }
    }
}
