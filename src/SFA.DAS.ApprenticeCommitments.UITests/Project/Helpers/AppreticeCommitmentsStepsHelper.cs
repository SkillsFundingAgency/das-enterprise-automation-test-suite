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
            var error = passwordPage.InvalidPassword(config.AC_AccountPassword, $"{config.AC_AccountPassword}1");
            StringAssert.Contains("There is a problem", error, "Password error message did not match");
        }

        public SignIntoApprenticeshipPortalPage SignInPage() => sigUpCompletePage.ClickSignInToApprenticePortal();

        public void VerifyApprenticeshipDataDisplayed(ConfirmYourApprenticeshipDetailsPage confirmYourApprenticeshipDetailsPage)
        {
            var (expectedApprenticeshipName, expectedLevelValue) = SplitTrainingName();
            Assert.AreEqual(expectedApprenticeshipName, confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo());
            Assert.AreEqual(expectedLevelValue, confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo());
            
            var (expectedStartDate, expectedEndDate, expectedDuration) = GetExpectedTrainingDates();
            var actualStartDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            var actualEndDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedEndDateInfo();

            Assert.AreEqual(actualStartDate, expectedStartDate.ToString("MMMM yyyy"));
            Assert.AreEqual(actualEndDate, expectedEndDate.ToString("MMMM yyyy"));
            Assert.AreEqual(expectedDuration + " months", confirmYourApprenticeshipDetailsPage.GetApprenticeshipDurationInfo());
        }

        public void VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(AlreadyConfirmedApprenticeshipDetailsPage alreadyConfirmedApprenticeshipDetailsPage)
        {
            var (expectedApprenticeshipName, expectedLevelValue) = SplitTrainingName();
            Assert.AreEqual(expectedApprenticeshipName, alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipInfo());
            Assert.AreEqual(expectedLevelValue, alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipLevelInfo());

            var (expectedStartDate, expectedEndDate, expectedDuration) = GetExpectedTrainingDates();
            var actualStartDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            var actualEndDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedEndDateInfo();

            Assert.AreEqual(actualStartDate, expectedStartDate.ToString("MMMM yyyy"));
            Assert.AreEqual(actualEndDate, expectedEndDate.ToString("MMMM yyyy"));
            Assert.AreEqual(expectedDuration + " months", alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipDurationInfo());
        }

        private (string, string) SplitTrainingName()
        {
            var trainingInfo = _objectContext.GetTrainingName();
            return (trainingInfo.Split(',')[0], trainingInfo.Split(':')[1].Trim()[0].ToString());
        }

        private (DateTime, DateTime, int) GetExpectedTrainingDates()
        {
            var expectedStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
            var expectedEndDate = DateTime.Parse(_objectContext.GetTrainingEndDate());
            var expectedDuration = Math.Abs(12 * (expectedStartDate.Year - expectedEndDate.Year) + expectedStartDate.Month - expectedEndDate.Month) + 1;
            return (expectedStartDate, expectedEndDate, expectedDuration);
        }

        private void OpenInNewTab(string url) => _context.Get<TabHelper>().OpenInNewTab(url);

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);
    }
}
