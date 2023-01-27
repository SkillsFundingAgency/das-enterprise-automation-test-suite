using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Hooks
{
    [Binding]
    public class AfterScenarioHooks
    {
        protected readonly ObjectContext _objectContext;
        protected readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _aLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsAccountsSqlDbHelper _apprenticeCommitmentsAccountsSqlDbHelper;
        private readonly AccountsAndCommitmentsSqlHelper _accountsAndCommitmentsSqlHelper;
        private readonly TryCatchExceptionHelper _tryCatch;
        protected readonly string[] tags;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _aLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsAccountsSqlDbHelper = context.Get<ApprenticeCommitmentsAccountsSqlDbHelper>();
            _accountsAndCommitmentsSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            tags = context.ScenarioInfo.Tags;
        }

        [AfterScenario(Order = 33)]
        public void ClearDownUserData() => _tryCatch.AfterScenarioException(() => ClearDownUserDataQuery());

        public void ClearDownUserDataQuery()
        {
            string apprenticeId;
            var email = _objectContext.GetApprenticeEmail();

            if (tags.Contains("deletecmaddatacreatedthroughapi_RegAndAppTablesOnly"))
            {
                _aComtSqlDbHelper.DeleteRegistrationTableData(email); //acomt db
                _accountsAndCommitmentsSqlHelper.ResetEmailForApprenticeshipRecord(email); //Commitments db
                return;
            }
            else if (tags.Contains("deletecmaddatacreatedthroughapi"))
            {
                if (tags.Contains("cmadupdatedemail"))
                    apprenticeId = _aLoginSqlDbHelper.GetApprenticeIdFromAspNetUsersTable(_objectContext.GetApprenticeChangedEmail());
                else
                    apprenticeId = _aLoginSqlDbHelper.GetApprenticeIdFromAspNetUsersTable(email);

                //appacc db
                _apprenticeCommitmentsAccountsSqlDbHelper.DeleteEmailAddressHistoryTableData(apprenticeId);
                _apprenticeCommitmentsAccountsSqlDbHelper.DeleteApprenticeTableData(apprenticeId);

                //alogin db
                _aLoginSqlDbHelper.DeleteAspNetUsersTableDataForCMAD(apprenticeId);
                _aLoginSqlDbHelper.DeleteResetPasswordRequestsTableData(email);
                _aLoginSqlDbHelper.DeleteUserLogsTableData(email);

                //acomt db
                _aComtSqlDbHelper.DeleteRevisionAndApprenticeshipTableData(apprenticeId, email);
                _aComtSqlDbHelper.DeleteRegistrationTableData(email);

                //Commitments db
                _accountsAndCommitmentsSqlHelper.ResetEmailForApprenticeshipRecord(email);
            }
        }
    }
}
