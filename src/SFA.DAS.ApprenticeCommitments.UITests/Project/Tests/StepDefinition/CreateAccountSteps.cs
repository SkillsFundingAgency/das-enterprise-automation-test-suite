using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
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
            var passwordPage = GetCreatePasswordPage();

            passwordPage.CreatePassword();
        }

        [Then(@"an error is shown for invalid passwords")]
        public void ThenAnErrorIsShownForInvalidPasswords()
        {
            var passwordPage = GetCreatePasswordPage();

            var invalidPasswords = new List<string []> 
            {
                new string [] { _config.AC_AccountPassword, $"{_config.AC_AccountPassword}1" },
                new string [] { "invalidpassword", "invalidpassword" },
                new string [] { "234547896", "234547896" },
                new string [] { "ac1234", "ac1234" },
                new string [] { "AccountsPassword123", "AccountsPassword123" }
            };

            foreach (var invalidPassword in invalidPasswords)
            {
                passwordPage = passwordPage.InvalidPassword(invalidPassword[0], invalidPassword[1]);

                passwordPage.VerifyErrorSummary();
            }
        }

        private CreatePasswordPage GetCreatePasswordPage()
        {
            string invitationId = string.Empty;

            string email = _objectContext.GetApprenticeEmail();

            _assertHelper.RetryOnNUnitException(() =>
            {
                invitationId = _apprenticeLoginSqlDbHelper.GetId(email);

                Assert.IsNotEmpty(invitationId, $"Invitation id not found in the Login db for email '{email}'");
            });

            return new CreatePasswordPage(_context, invitationId);
        }
    }
}
