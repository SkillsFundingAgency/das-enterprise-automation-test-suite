using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class CreateAccountStepsHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext _objectContext;
        protected readonly RetryAssertHelper _assertHelper;
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper;
        protected readonly TabHelper tabHelper;

        public CreateAccountStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<RetryAssertHelper>();
            _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            appreticeCommitmentsApiHelper = new ApprenticeCommitmentsApiHelper(context);
            tabHelper = context.Get<TabHelper>();
        }

        public StartPage OpenLatestInvitation(int noOfRegistrations)
        {
            string email = GetApprenticeEmail();

            RetryGetRegistrationId(() =>
            {
                var registrationIds = _aComtSqlDbHelper.GetRegistrationIds(email).ToList();
                Assert.AreEqual(noOfRegistrations, registrationIds.Count, $"Registration id expected to be {noOfRegistrations} in total but found {registrationIds.Count} in the aComt db for email '{email}'");
            });

            return OpenInvitation(_aComtSqlDbHelper.GetRegistrationId(email, _context.ScenarioInfo.Title));
        }

        public ApprenticeOverviewPage CreateAccountViaApiAndConfirmApprenticeshipViaDb()
        {
            var page = CreateAccountViaApi();
            _aComtSqlDbHelper.ConfirmApprenticeship(GetApprenticeEmail());
            return page.NavigateToOverviewPageFromTopNavigationLink();
        }


        public ApprenticeOverviewPage CreateAccountViaUIAndConfirmApprenticeshipViaDb()
        {
            var page = ConfirmIdentityAndGoToApprenticeHomePage();
            _aComtSqlDbHelper.ConfirmApprenticeship(GetApprenticeEmail());
            return page.NavigateToOverviewPageFromTopNavigationLink();
        }

        public ApprenticeHomePage CreateAccountViaApi()
        {
            CreateApprenticeshipViaApiRequest();

            var apprenticeHomePage = ConfirmIdentityAndGoToApprenticeHomePage();
            _aComtSqlDbHelper.UpdateConfirmBeforeFieldInCommitmentStatementTable(GetApprenticeEmail());
            return apprenticeHomePage;
        }

        public SignIntoMyApprenticeshipPage CreateAccountAndSignOutBeforeConfirmingPersonalDetails()
        {
            CreateApprenticeshipViaApiRequest();
            return CreateAccountAndGetToCreateMyApprenticeshipAccountPage().SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();
        }

        public void CreateApprenticeshipViaApiRequest() => appreticeCommitmentsApiHelper.CreateApprenticeshipViaCommitmentsJobApiRequest();

        public CreateMyApprenticeshipAccountPage CreateAccountAndGetToCreateMyApprenticeshipAccountPage() => NavigateToCreateLoginDetailsPage().EnterDetailsOnCreateLoginDetailsPageAndContinue();

        public CreateLoginDetailsPage NavigateToCreateLoginDetailsPage() => OpenLatestInvitation(1).CTAOnStartPageToSignIn().ClickCreateAnAccountLinkOnSignInPage();

        public ApprenticeHomePage ConfirmIdentityAndGoToApprenticeHomePage() => CreateAccountAndGetToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage().AcceptTermsAndCondition(true);

        private StartPage OpenInvitation(string registrationId)
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(registrationId));
            _objectContext.SetRegistrationId(registrationId);
            return new StartPage(_context);
        }

        private void RetryGetRegistrationId(Action action) => _assertHelper.RetryOnNUnitException(action);

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();
    }
}
