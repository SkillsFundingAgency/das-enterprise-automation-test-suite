using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    public class CreateAccountStepsHelper(ScenarioContext context)
    {
        private readonly ScenarioContext _context = context;
        protected readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        protected readonly RetryAssertHelper _assertHelper = context.Get<RetryAssertHelper>();
        protected readonly ApprenticeLoginSqlDbHelper _apprenticeLoginSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
        private readonly CommitmentsSqlHelper _commitmentsSqlHelper = context.Get<CommitmentsSqlHelper>();
        protected readonly ApprenticeCommitmentsApiHelper appreticeCommitmentsApiHelper = new(context);
        protected readonly TabHelper tabHelper = context.Get<TabHelper>();
        private static readonly int[] x = [5, 8, 10];

        public StartPage OpenLatestInvitation(int noOfRegistrations)
        {
            string email = GetApprenticeEmail();

            RetryGetRegistrationId(() =>
            {
                var registrationIds = _aComtSqlDbHelper.GetRegistrationIds(email);

                Assert.IsTrue(registrationIds.All(x => !string.IsNullOrEmpty(x)), $"Registration Id can not be found for email {email}");

                Assert.AreEqual(noOfRegistrations, registrationIds.Count, $"Registration id expected to be {noOfRegistrations} in total but found {registrationIds.Count} in the aComt db for email '{email}'");
            });

            return OpenInvitation(_aComtSqlDbHelper.GetRegistrationId(email));
        }

        public ApprenticeOverviewPage CreateAccountViaApiAndConfirmApprenticeshipViaDb()
        {
            var page = CreateAccountViaApi();
            _aComtSqlDbHelper.ConfirmApprenticeship(GetApprenticeEmail());
            return page.NavigateToOverviewPageFromTopNavigationLink();
        }


        public FullyConfirmedOverviewPage CreateAccountViaUIAndConfirmApprenticeshipViaDb()
        {
            var page = ConfirmIdentityAndGoToApprenticeHomePage();
            _aComtSqlDbHelper.ConfirmApprenticeship(GetApprenticeEmail());
            return page.NavigateToOverviewPageFromTopNavigationLinkForDbConfirmedDetails();
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

        public void CreateApprenticeshipViaApiRequest() => appreticeCommitmentsApiHelper.CreateApprovalsCreatedEvent();

        public CreateMyApprenticeshipAccountPage CreateAccountAndGetToCreateMyApprenticeshipAccountPage() => NavigateToCreateLoginDetailsPage().EnterDetailsOnCreateLoginDetailsPageAndContinue();

        public CreateLoginDetailsPage NavigateToCreateLoginDetailsPage() => OpenLatestInvitation(1).CTAOnStartPageToSignIn().ClickCreateAnAccountLinkOnSignInPage();

        public ApprenticeHomePage ConfirmIdentityAndGoToApprenticeHomePage()
        {
            var (trainingName, trainingStartDate) = _commitmentsSqlHelper.GetTrainingNameAndStartDate(_objectContext.GetApprenticeEmail());

            _objectContext.SetTrainingName(trainingName);
            _objectContext.SetTrainingStartDate(trainingStartDate);

            return CreateAccountAndGetToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage().AcceptTermsAndConditionForPositiveMatch(true);
        }

        private StartPage OpenInvitation(string registrationId)
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(registrationId));
            _objectContext.SetRegistrationId(registrationId);
            return new StartPage(_context);
        }

        private void RetryGetRegistrationId(Action action) => _assertHelper.RetryOnNUnitException(action, RetryTimeOut.GetTimeSpan(x));

        private string GetApprenticeEmail() => _objectContext.GetApprenticeEmail();
    }
}
