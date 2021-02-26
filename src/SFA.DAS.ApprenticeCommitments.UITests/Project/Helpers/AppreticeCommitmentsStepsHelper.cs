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

        private YourAccountHasBeenCreatedPage sigUpCompletePage;

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
            RetryOnNUnitException(() =>
            {
                string email = _objectContext.GetApprenticeEmail();

                var invitationId = _apprenticeLoginSqlDbHelper.GetId(email);

                Assert.IsNotEmpty(invitationId, $"Invitation id not found in the Login db for email '{email}'");

                OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(invitationId));
            });

            return new CreatePasswordPage(_context);
        }

        public ResetPasswordPage GetResetPasswordPage()
        {
            RetryOnNUnitException(() =>
            {
                (string clientId, string requestId) id = (string.Empty, string.Empty);

                string email = _objectContext.GetApprenticeEmail();

                id = _apprenticeLoginSqlDbHelper.GetApprenticeResetLoginData(email);

                Assert.IsNotEmpty(id.clientId, $"Client id not found in the Login db for email '{email}'");

                Assert.IsNotEmpty(id.requestId, $"Request id not found in the Login db for email '{email}'");

                OpenInNewTab(UrlConfig.Apprentice_ResetPasswordUrl(id.clientId, id.requestId));
            });

            return new ResetPasswordPage(_context);
        }

        public YourAccountHasBeenCreatedPage CreateAccount(bool postApprenticeship = true)
        {
            if (postApprenticeship)
            CreateApprenticeship();

            return sigUpCompletePage = GetCreatePasswordPage().CreatePassword(); 
        }

        public ForgottenPasswordConfirmPage SubmitResetPassword() => SignInPage().Resetpassword().Submit();

        public PasswordResetSuccessfulPage ResetPassword() => GetResetPasswordPage().CreatePassword();

        public ConfirmYourIdentityPage SignInToApprenticePortal() => SignInPage().SignInToApprenticePortal();

        public void InvalidPassword(PasswordBasePage passwordPage)
        {
            passwordPage = passwordPage.InvalidPassword(config.AC_AccountPassword, $"{config.AC_AccountPassword}1");

            passwordPage.VerifyErrorSummary();
        }

        public SignIntoApprenticeshipPortalPage SignInPage() => sigUpCompletePage.ClickSignInToApprenticePortal();

        private void OpenInNewTab(string url) => _context.Get<TabHelper>().OpenInNewTab(url);

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);
    }
}
