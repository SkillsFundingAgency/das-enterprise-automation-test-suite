using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding, Scope(Tag = "deleteinvitation")]
    public class AfterScenarioHooks
    {
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeCommitmentsRegistrationSqlDbHelper _apprenticeCommitmentsRegistrationSqlDbHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;


        public AfterScenarioHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _apprenticeCommitmentsRegistrationSqlDbHelper = context.Get<ApprenticeCommitmentsRegistrationSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        [AfterScenario(Order = 32)]
        public void ClearDownData()
        {
            var email = _objectContext.GetApprenticeEmail();

            _apprenticeLoginSqlDbHelper.DeleteInvitation(email);

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteRegistration(email);

            _apprenticeLoginSqlDbHelper.DeleteUserLogs(email);
        }
    }
}
