using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding, Scope(Tag = "apprenticecommitmentscreateaccount")]
    public class CreateAccountHooks
    {
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeCommitmentsRegistrationSqlDbHelper _apprenticeCommitmentsRegistrationSqlDbHelper;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;


        public CreateAccountHooks(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _apprenticeCommitmentsRegistrationSqlDbHelper = context.Get<ApprenticeCommitmentsRegistrationSqlDbHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownData()
        {
            var email = _objectContext.GetApprenticeEmail();

            _apprenticeCommitmentsRegistrationSqlDbHelper.DeleteRegistration(email);

            _apprenticeLoginSqlDbHelper.DeleteUser(email);
        }
    }
}
