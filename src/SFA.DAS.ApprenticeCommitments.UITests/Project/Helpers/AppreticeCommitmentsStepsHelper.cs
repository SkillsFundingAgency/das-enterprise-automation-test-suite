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

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class AppreticeCommitmentsStepsHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext _objectContext;
        protected readonly AssertHelper _assertHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        private readonly ApprenticeCommitmentsConfig config;

        private SigUpCompletePage sigUpCompletePage;

        public AppreticeCommitmentsStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<AssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
            config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
        }

        public void CreateApprenticeship() => appreticeCommitmentsApiHelper.CreateApprenticeship();

        public CreatePasswordPage GetCreatePasswordPage()
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

        public ResetPasswordPage GetResetPasswordPage()
        {
            (string clientId, string requestId) id = (string.Empty, string.Empty);

            string email = _objectContext.GetApprenticeEmail();

            _assertHelper.RetryOnNUnitException(() =>
            {
                id = _apprenticeLoginSqlDbHelper.GetApprenticeResetLoginData(email);

                Assert.IsNotEmpty(id.requestId, $"Client id not found in the Login db for email '{email}'");
            });

            return new ResetPasswordPage(_context, id);
        }

        public SigUpCompletePage CreateAccount(bool postApprenticeship = true)
        {
            if (postApprenticeship)
            CreateApprenticeship();

            return sigUpCompletePage = GetCreatePasswordPage().CreatePassword(); 
        }

        public ForgottenPasswordConfirmPage SubmitResetPassword() => SignInPage().Resetpassword().Submit();

        public SigUpCompletePage ResetPassword() => sigUpCompletePage = GetResetPasswordPage().CreatePassword();

        public ConfirmYourIdentityPage SignInToApprenticePortal() => SignInPage().SignInToApprenticePortal();

        public void InvalidPassword(PasswordBasePage passwordPage)
        {
            var invalidPasswords = new List<string[]>
            {
                new string [] { config.AC_AccountPassword, $"{config.AC_AccountPassword}1" },
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

        public SignIntoApprenticeshipPortalPage SignInPage() => sigUpCompletePage.ClickSignInToApprenticePortal();
    }
}
