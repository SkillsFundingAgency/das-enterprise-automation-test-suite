using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public abstract class DeleteBaseHooks
    {
        protected readonly ObjectContext _objectContext;
        protected readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeLoginSqlDbHelper _aLoginSqlDbHelper;
        protected readonly ApprenticeCommitmentsDataHelper _apprenticeCommitmentsDataHelper;

        public DeleteBaseHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _aLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
        }

        public void ClearDownInvitation()
        {
            var email = _objectContext.GetApprenticeEmail();

            _aLoginSqlDbHelper.DeleteInvitation(email);

            _aComtSqlDbHelper.DeleteRegistration(email);

            _aLoginSqlDbHelper.DeleteUserLogs(email);
        }

        public void ClearDownUser()
        {
            ClearDownInvitation();

            var email = _objectContext.GetApprenticeEmail();

            _aLoginSqlDbHelper.DeleteUser(email);

            _aLoginSqlDbHelper.DeleteUserRequests(email);

            _aComtSqlDbHelper.DeleteApprentice(email);

            _aComtSqlDbHelper.DeleteApprentice(_apprenticeCommitmentsDataHelper.NewEmail);
        }
    }
}
