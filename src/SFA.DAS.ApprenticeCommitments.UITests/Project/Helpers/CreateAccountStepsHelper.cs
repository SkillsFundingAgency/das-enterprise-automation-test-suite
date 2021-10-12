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
            string registrationId = string.Empty;

            RetryOnNUnitException(() =>
            {
                string email = GetApprenticeEmail();
                
                var registrationIds = _aComtSqlDbHelper.GetRegistrationIds(email).ToList();

                Assert.AreEqual(noOfRegistrations, registrationIds.Count, $"Registration id expected to be {noOfRegistrations} in total but found {registrationIds.Count}int the aComt db for email '{email}'");

                registrationId = registrationIds.Last();
            });

            return OpenInvitation(registrationId);
        }

        public StartPage GetStartPage()
        {
            string registrationId = string.Empty;

            RetryOnNUnitException(() =>
            {
                string email = GetApprenticeEmail();

                var registrationId = _aComtSqlDbHelper.GetRegistrationId(email, _context.ScenarioInfo.Title);

                Assert.IsNotEmpty(registrationId, $"Registration id not found in the aComt db for email '{email}'");
            });

            return OpenInvitation(registrationId);
        }

        public ApprenticeHomePage CreateAccount()
        {
            CreateApprenticeshipViaApiRequest();
            
            var apprenticeHomePage = ConfirmIdentity();
            
            _aComtSqlDbHelper.UpdateConfirmBeforeFieldInCommitmentStatementTable(_objectContext.GetApprenticeEmail());
            
            return apprenticeHomePage;
        }

        public SignIntoMyApprenticeshipPage CreateAccountAndSignOutBeforeConfirmingPersonalDetails()
        {
            CreateApprenticeshipViaApiRequest();
            return CreateAccountAndGetToCreateMyApprenticeshipAccountPage().SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();
        }

        public void CreateApprenticeshipViaApiRequest() => appreticeCommitmentsApiHelper.CreateApprenticeshipViaCommitmentsJobApiRequest();

        public CreateMyApprenticeshipAccountPage CreateAccountAndGetToCreateMyApprenticeshipAccountPage() => NavigateToCreateLoginDetailsPage().EnterDetailsOnCreateLoginDetailsPageAndContinue();

        public CreateLoginDetailsPage NavigateToCreateLoginDetailsPage() => GetStartPage().CTAOnStartPageToSignIn().ClickCreateAnAccountLinkOnSignInPage();

        public ApprenticeHomePage ConfirmIdentity() => CreateAccountAndGetToCreateMyApprenticeshipAccountPage().ConfirmIdentity();

        private StartPage OpenInvitation(string registrationId)
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(registrationId));

            return new StartPage(_context);
        }

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();
    }
}
