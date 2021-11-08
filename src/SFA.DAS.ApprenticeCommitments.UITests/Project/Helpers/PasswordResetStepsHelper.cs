using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class PasswordResetStepsHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext _objectContext;
        protected readonly RetryAssertHelper _assertHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        protected readonly CreateAccountStepsHelper createAccountStepsHelper;
        private readonly ApprenticeCommitmentsConfig config;
        protected readonly TabHelper tabHelper;

        public PasswordResetStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
            createAccountStepsHelper = new CreateAccountStepsHelper(context);
            config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            tabHelper = context.Get<TabHelper>();
        }

        public ResetPasswordPage BuildResetPasswordPageUsingDBHelper()
        {
            RetryOnNUnitException(() =>
            {
                (string clientId, string requestId) id = (string.Empty, string.Empty);
                string email = _objectContext.GetApprenticeEmail();
                id = _apprenticeLoginSqlDbHelper.GetApprenticeResetLoginData(email);

                Assert.IsNotEmpty(id.clientId, $"Client id not found in the Login db for email '{email}'");
                Assert.IsNotEmpty(id.requestId, $"Request id not found in the Login db for email '{email}'");

                tabHelper.OpenInNewTab(UrlConfig.Apprentice_ResetPasswordUrl(id.clientId, id.requestId));
            });

            return new ResetPasswordPage(_context);
        }

        public ForgottenPasswordConfirmPage ResetPasswordFromSignInPageForUnverifiedAccount(SignIntoMyApprenticeshipPage signIntoMyApprenticeshipPage) => signIntoMyApprenticeshipPage.ClickForgottenMyPasswordLinkOnSignInPage().SubmitEmailOnForgottenPasswordPage();

        public SignIntoMyApprenticeshipPage ResetPasswordAndReturnToSignInPage() => BuildResetPasswordPageUsingDBHelper().UpdatePassword().ReturnToSignInPage();

        public void EnterMismatchedPasswordsAndValidateError(ResetPasswordPage resetPasswordPage)
        {
            resetPasswordPage.EnterMismatchedPasswordsOnResetPasswordPage(config.AC_AccountPassword);
            resetPasswordPage.VerifyErrorSummaryTitle();
            resetPasswordPage.VerifyMismatchPasswordErrorOnPasswordResetPage();
        }

        public void EnterMismatchedPasswordsAndValidateErrorOnCreateLoginDetailsPage(CreateLoginDetailsPage createLoginDetailsPage)
        {
            createLoginDetailsPage.EnterMismatchedPasswordsOnCreateLoginDetailsPage(config.AC_AccountPassword);
            createLoginDetailsPage.VerifyErrorSummaryTitle();
            createLoginDetailsPage.VerifyMismatchPasswordErrorOnCreateLoginDetailsPage();
        }

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);
    }
}
