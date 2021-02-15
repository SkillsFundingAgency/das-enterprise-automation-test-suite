using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeCommitmentsApiHelper _appreticeCommitmentsApiHelper;
        private readonly AssertHelper _assertHelper;
        private readonly ApprenticeCommitmentsConfig _config;
        private readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<AssertHelper>();
            _appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
            _config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }

        [When(@"employer or provider submits the details to create an account")]
        public void WhenEmployerOrProviderSubmitsTheDetailsToCreateAnAccount() => _appreticeCommitmentsApiHelper.CreateApprenticeship();

        [Then(@"the apprentice is able to create an account using the invitation")]
        public void ThenTheApprenticeIsAbleToCreateAnAccountUsingTheInvitation()
        {
            string invitationId = string.Empty;

            string email = _objectContext.GetApprenticeEmail();

            string pasword = _config.AC_AccountPassword;

            _assertHelper.RetryOnNUnitException(() =>
            {
                invitationId = _apprenticeLoginSqlDbHelper.GetId(email);

                Assert.IsNotEmpty(invitationId, $"Invitation id not found in the Login db for email '{email}'");
            });

            new CreatePasswordPage(_context).CreatePassword(pasword);
        }
    }
}
