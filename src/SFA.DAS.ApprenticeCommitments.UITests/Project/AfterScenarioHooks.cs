using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project
{
    [Binding, Scope(Tag = "deleteuser")]
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

        [AfterScenario(Order = 33)]
        public void ClearDownData()
        {
            var email = _objectContext.GetApprenticeEmail();

            _apprenticeLoginSqlDbHelper.DeleteUser(email);

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteApprentice(email);
        }
    }
}
