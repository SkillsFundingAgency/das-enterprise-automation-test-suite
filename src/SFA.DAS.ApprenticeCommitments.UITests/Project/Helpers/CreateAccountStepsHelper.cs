using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
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
        private SignIntoMyApprenticeshipPage _signIntoMyApprenticeshipPage;
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

        public StartPage GetStartPage()
        {
            RetryOnNUnitException(() =>
            {
                string email = _objectContext.GetApprenticeEmail();
                var registrationId = _aComtSqlDbHelper.GetRegistrationId(email);

                Assert.IsNotEmpty(registrationId, $"Registration id not found in the aComt db for email '{email}'");
                tabHelper.OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(registrationId));
            });

            return new StartPage(_context);
        }

        public ApprenticeHomePage CreateAccount()
        {
            CreateApprenticeshipViaApiRequest();
            return CreateAccountAndGetToConfirmIdentityPage().ConfirmIdentity();
        }

        public SignIntoMyApprenticeshipPage CreateAccountAndSignOutBeforeConfirmingPersonalDetails()
        {
            CreateApprenticeshipViaApiRequest();
            return _signIntoMyApprenticeshipPage = CreateAccount().SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();
        }

        public void CreateApprenticeshipViaApiRequest() => appreticeCommitmentsApiHelper.CreateApprenticeshipViaCommitmentsJobApiRequest();

        public CreateMyApprenticeshipAccountPage CreateAccountAndGetToConfirmIdentityPage() => NavigateToCreateLoginDetailsPage().EnterDetailsOnCreateLoginDetailsPageAndContinue();

        public CreateLoginDetailsPage NavigateToCreateLoginDetailsPage() => GetStartPage().CTAOnStartPageToSignIn().ClickCreateAnAccountLinkOnSignInPage();

        private void RetryOnNUnitException(Action action) => _assertHelper.RetryOnNUnitException(action);
    }
}
