using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Transfers.UITests.Project.Helpers;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransfersEmployerStepsHelper _employerStepsHelper;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly TransfersUser _transfersUser;
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
            _employerStepsHelper = new TransfersEmployerStepsHelper(context);
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
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
        public void CheckTheSenderTransferStatus(string expectedtransferStatus)
        {
            var actualtransferStatus = _homePage.GoToYourOrganisationsAndAgreementsPage().GetTransfersStatus();

            Assert.IsTrue(actualtransferStatus.ContainsCompareCaseInsensitive(expectedtransferStatus), $"Expected {expectedtransferStatus}, Actual {actualtransferStatus}");
        }

        [Given(@"Receiver sends a cohort to the provider for review and approval")]
        public void GivenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            LoginAsReceiver();

            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider();
        }

        [Given(@"Receiver sends an approved cohort to the provider")]
        public void GivenReceiverSendsAnApprovedCohortToTheProvider()
        {
            LoginAsReceiver();

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerStepsHelper.Approve();

        [When(@"Provider approves the cohort and sends to recevier for approval")]
        public void WhenProviderApprovesTheCohortAndSendsToRecevierForApproval() => _providerStepsHelper.ApprovesTheCohortsAndSendsToEmployer();

        [When(@"Provider adds an apprentices approves the cohort")]
        public void WhenProviderAddsAnApprenticesApprovesTheCohort() => _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

        [When(@"Receiver edits and sends an approved cohort to the provider")]
        public void WhenReceiverEditsAndSendsAnApprovedCohortToTheProvider()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            _employerStepsHelper.OpenRejectedCohort()
                .SelectEditApprentice()
                .EditApprenticePreApprovalAndSubmit()
                .EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [When(@"Receiver sends a cohort to the provider for review and approval")]
        public void WhenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            _employerStepsHelper.OpenRejectedCohort().EmployerSendsToTrainingProviderForReview();
        }

        [When(@"Receiver approves the cohort")]
        public void WhenReceiverApprovesTheCohort()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            _employerStepsHelper.Approve();
        }

        [When(@"Sender approves the cohort")]
        public void WhenSenderApprovesTheCohort()
        {
            _objectContext.UpdateOrganisationName(_sender);

            _employerStepsHelper.ApproveTransfersRequest();
        }

        [When(@"Sender rejects the cohort")]
        public void WhenSenderRejectsTheCohort()
        {
            _objectContext.UpdateOrganisationName(_sender);

            _employerStepsHelper.RejectTransfersRequest();
        }


        [Then(@"Verify a new live apprenticeship record is created")]
        public void ThenVerifyANewLiveApprenticeshipRecordIsCreated()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            var manageYourApprenticePage = _employerStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }

        private void LoginAsReceiver() => Login(_receiver);

        private void LoginAsSender() => Login(_sender);

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _homePage = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }
    }
}