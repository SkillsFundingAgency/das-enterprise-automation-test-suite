using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using Polly;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransfersEmployerStepsHelper _transferEmployerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly TransfersUser _transfersUser;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private HomePage _homePage;

        private readonly string _sender;
        private readonly string _receiver;

        public TransfersSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransfersUser>();
            _sender = _transfersUser.OrganisationName;
            _receiver = _transfersUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _transferEmployerStepsHelper = new TransfersEmployerStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"We have a Sender with sufficient levy funds")]
        public void GivenWeHaveASenderWithSufficientLevyFunds() => LoginAsSender();

        [Given(@"We have a Sender with sufficient levy funds without signing an agreement")]
        public void GivenWeHaveASenderWithSufficientLevyFundsWithoutSigningAnAgreement()
        {
            _homePage = _employerPortalLoginHelper.Login(_context.GetUser<AgreementNotSignedTransfersUser>(), true);
        }

        [Then(@"the sender transfer status is (disabled|enabled)")]
        public void CheckTheSenderTransferStatus(string expectedtransferStatus) => _homePage.GoToYourOrganisationsAndAgreementsPage().VerifyTransfersStatus(expectedtransferStatus);

        [Given(@"Receiver sends a cohort to the provider for review and approval")]
        public void GivenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            LoginAsReceiver();

            _transferEmployerStepsHelper.EmployerCreateCohortAndSendsToProvider();
        }

        [Given(@"Receiver sends an approved cohort with (.*) apprentices to the provider")]
        public void GivenReceiverSendsAnApprovedCohortWithApprenticesToTheProvider(int numberOfApprentices)
        {
            LoginAsReceiver();

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }


        [When(@"the Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerStepsHelper.Approve();

        [When(@"Provider approves the cohort and sends to recevier for approval")]
        public void WhenProviderApprovesTheCohortAndSendsToRecevierForApproval() => _providerStepsHelper.ApprovesTheCohortsAndSendsToEmployer();

        [When(@"Provider adds an apprentices approves the cohort")]
        public void WhenProviderAddsAnApprenticesApprovesTheCohort() => _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

        [When(@"Receiver edits and sends an approved cohort to the provider")]
        public void WhenReceiverEditsAndSendsAnApprovedCohortToTheProvider()
        {
            UpdateOrganisationName(_receiver);

            _transferEmployerStepsHelper.OpenRejectedCohort()
                .SelectEditApprentice()
                .EditApprenticePreApprovalAndSubmit()
                .EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [When(@"Receiver sends a cohort to the provider for review and approval")]
        public void WhenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            UpdateOrganisationName(_receiver);

            _transferEmployerStepsHelper.OpenRejectedCohort().EmployerSendsToTrainingProviderForReview();
        }

        [When(@"Receiver approves the cohort")]
        public void WhenReceiverApprovesTheCohort()
        {
            UpdateOrganisationName(_receiver);

            _employerStepsHelper.Approve();
        }

        [When(@"Sender approves the cohort")]
        public void WhenSenderApprovesTheCohort()
        {
            UpdateOrganisationName(_sender);

            _transferEmployerStepsHelper.ApproveTransfersRequest();
        }

        [When(@"Sender rejects the cohort")]
        public void WhenSenderRejectsTheCohort()
        {
            UpdateOrganisationName(_sender);

            _transferEmployerStepsHelper.RejectTransfersRequest();
        }

        [Then(@"Verify a new live apprenticeship record is created")]
        public void ThenVerifyANewLiveApprenticeshipRecordIsCreated()
        {
            UpdateOrganisationName(_receiver);

            var manageYourApprenticePage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }

        private void LoginAsReceiver() => Login(_receiver);

        private void LoginAsSender() => Login(_sender);

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _homePage = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }

        private void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);
    }
}