using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class PasswordResetStepsHelper(ScenarioContext context)
    {
        protected readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        protected readonly RetryAssertHelper _assertHelper = context.Get<RetryAssertHelper>();
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper = new(context);
        protected readonly CreateAccountStepsHelper createAccountStepsHelper = new(context);
        private readonly ApprenticeCommitmentsConfig config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
        protected readonly TabHelper tabHelper = context.Get<TabHelper>();

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

            return new ResetPasswordPage(context);
        }

        public static ForgottenPasswordConfirmPage ResetPasswordFromSignInPageForUnverifiedAccount(SignIntoMyApprenticeshipPage signIntoMyApprenticeshipPage) => signIntoMyApprenticeshipPage.ClickChangeYourPasswordLinkOnSignInPage().SubmitEmailOnForgottenPasswordPage();

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

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitExceptionWithLongerTimeOut(action);
    }
}
