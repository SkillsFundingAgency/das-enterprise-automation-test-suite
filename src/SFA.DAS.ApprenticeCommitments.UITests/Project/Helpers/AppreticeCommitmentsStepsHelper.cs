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
        private string expectedApprenticeshipName, expectedApprenticeshipLevel, expectedApprenticeshipDuration;
        private DateTime expectedApprenticeshipStartDate, expectedApprenticeshipEndDate;
        private string actualApprenticeshipName, actualApprenticeshipLevel, actualApprenticeshipStartDate, actualApprenticeshipEndDate, actualApprenticeshipDuration;

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
            PopulateExpectedApprenticeshipDetails();
            actualApprenticeshipName = confirmYourApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = confirmYourApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualApprenticeshipEndDate = confirmYourApprenticeshipDetailsPage.GetApprenticeshipPlannedEndDateInfo();
            actualApprenticeshipDuration = confirmYourApprenticeshipDetailsPage.GetApprenticeshipDurationInfo();

            AssertApprenticeshipDetails();
        }

        public void VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(AlreadyConfirmedApprenticeshipDetailsPage alreadyConfirmedApprenticeshipDetailsPage)
        {
            PopulateExpectedApprenticeshipDetails();
            actualApprenticeshipName = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipInfo();
            actualApprenticeshipLevel = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipLevelInfo();
            actualApprenticeshipStartDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedStartDateInfo();
            actualApprenticeshipEndDate = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipPlannedEndDateInfo();
            actualApprenticeshipDuration = alreadyConfirmedApprenticeshipDetailsPage.GetApprenticeshipDurationInfo();

            AssertApprenticeshipDetails();
        }

        public ConfirmRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesPage(ConfirmRolesAndResponsibilitiesPage confirmRolesAndResponsibilitiesPage)
        {
            return confirmRolesAndResponsibilitiesPage.VerifyRolesYouTab()
                .VerifyRolesYourEmployerTab()
                .VerifyRolesYourTrainingProviderTab();
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(AlreadyConfirmedRolesAndResponsibilitiesPage confirmRolesAndResponsibilitiesPage)
        {
            return confirmRolesAndResponsibilitiesPage.VerifyRolesYouTab()
                .VerifyRolesYourEmployerTab()
                .VerifyRolesYourTrainingProviderTab();
        }

        private void PopulateExpectedApprenticeshipDetails()
        {
            expectedApprenticeshipName = _objectContext.GetTrainingName().Split(',')[0];
            expectedApprenticeshipLevel = _objectContext.GetTrainingName().Split(':')[1].Trim()[0].ToString();
            expectedApprenticeshipStartDate = DateTime.Parse(_objectContext.GetTrainingStartDate());
            expectedApprenticeshipEndDate = DateTime.Parse(_objectContext.GetTrainingEndDate());
            expectedApprenticeshipDuration = CalculateMonthsBetweenDates(expectedApprenticeshipStartDate, expectedApprenticeshipEndDate);
        }

        private void AssertApprenticeshipDetails()
        {
            Assert.AreEqual(expectedApprenticeshipName, actualApprenticeshipName);
            Assert.AreEqual(expectedApprenticeshipLevel, actualApprenticeshipLevel);
            Assert.AreEqual(actualApprenticeshipStartDate, expectedApprenticeshipStartDate.ToString("MMMM yyyy"));
            Assert.AreEqual(actualApprenticeshipEndDate, expectedApprenticeshipEndDate.ToString("MMMM yyyy"));
            Assert.AreEqual($"{expectedApprenticeshipDuration} months", actualApprenticeshipDuration);
        }

        private string CalculateMonthsBetweenDates(DateTime startDate, DateTime endDate) =>
            (Math.Abs(12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month) + 1).ToString();

        private void OpenInNewTab(string url) => _context.Get<TabHelper>().OpenInNewTab(url);

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);
    }
}
