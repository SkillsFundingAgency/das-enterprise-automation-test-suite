using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly DataHelper _dataHelper;
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private HomePage _homePage;
        private string _senderAccountId;
        private string _recieverAccountId;
        private readonly string _sender;
        private readonly string _receiver;

        public TransfersSteps(ScenarioContext context)
        {
            _context = context;
            _sender = context.GetProjectConfig<ProjectConfig>().RE_OrganisationName;
            _receiver = context.GetTransfersConfig<TransfersConfig>().AP_ReceiverOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = _objectContext.GetDataHelper();
            _approvalsStepsHelper = new ApprovalsStepsHelper(context);
            _senderAccountId = null;
            _recieverAccountId = null;
        }

        [Given(@"We have a Sender with sufficient levy funds")]
        public void GivenWeHaveASenderWithSufficientLevyFunds()
        {
            LoginAsSender();
        }

        [Given(@"We have a Sender with sufficient levy funds without signing an agreement")]
        public void GivenWeHaveASenderWithSufficientLevyFundsWithoutSigningAnAgreement()
        {
            _objectContext.UpdateOrganisationName(_sender);

            _homePage = _employerPortalLoginHelper.Login(_context.GetUser<AgreementNotSignedTransfersUser>(), true);
        }

        [Given(@"We have a new Sender with sufficient levy funds and a new Receiver accounts setup")]
        public void GivenWeHaveANewSenderWithSufficientLevyFundsAndANewReceiverAccountsSetup()
        {
            _homePage = _approvalsStepsHelper.CreatesAccountAndSignAnAgreement();

            _senderAccountId = _objectContext.GetAccountId();

            _objectContext.UpdateDataHelper(new DataHelper(_dataHelper.TwoDigitProjectCode));

            new MongoDbDataGenerator(_context).AddGatewayUsers();

            _objectContext.UpdateOrganisationName(_receiver);

            _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage);

            _recieverAccountId = _objectContext.GetReceiverAccountId();
        }

        [When(@"Sender connects to Receiver")]
        public void WhenSenderConnectsToReceiver()
        {
            //Sender connects to receiver 
            _objectContext.UpdateOrganisationName(_sender);
            _homePage.GoToYourAccountsPage()
              .GoToHomePage(_sender);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(_objectContext.GetPublicReceiverAccountId())
                .SendTransferConnectionRequest()
                .GoToHomePage();

            //Receiver accepts the conneciton
            _objectContext.UpdateOrganisationName(_receiver);
            _homePage.GoToYourAccountsPage()
                 .GoToHomePage(_receiver);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ViewTransferConnectionRequestDetails(_sender)
                .AcceptTransferConnectionRequest()
                .GoToHomePage();
        }

        [Then(@"the sender transfer status is (disabled|enabled)")]
        public void CheckTheSenderTransferStatus(string expectedtransferStatus)
        {
            var actualtransferStatus = _homePage.GoToYourOrganisationsAndAgreementsPage().GetTransfersStatus();

            Assert.IsTrue(actualtransferStatus.ContainsCompareCaseInsensitive(expectedtransferStatus), $"Expected {expectedtransferStatus}, Actual {actualtransferStatus}");
        }

        [Then(@"A transfer connection is established successfully")]
        public void ThenATransferConnectionIsEstablishedSuccessfully()
        {
            _objectContext.UpdateOrganisationName(_sender);
            _homePage.GoToYourAccountsPage()
                .GoToHomePage(_sender);

            bool senderAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(_receiver);

            _objectContext.UpdateOrganisationName(_receiver);
            _homePage.GoToYourAccountsPage()
                .GoToHomePage(_receiver);

            bool receiverAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(_sender);

            if (!senderAssertion)
                if (!receiverAssertion)
                    throw new Exception($"We don't have an approved transfers connection between {_sender}({_senderAccountId}) and {_receiver}({_recieverAccountId})");
        }

        [Given(@"Receiver sends a cohort to the provider for review and approval")]
        public void GivenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            LoginAsReceiver();

            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider(true);
        }

        [Given(@"Receiver sends an approved cohort to the provider")]
        public void GivenReceiverSendsAnApprovedCohortToTheProvider()
        {
            LoginAsReceiver();

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1, true);

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort()
        {
            _providerStepsHelper.Approve();
        }

        [When(@"Provider approves the cohort and sends to recevier for approval")]
        public void WhenProviderApprovesTheCohortAndSendsToRecevierForApproval()
        {
            _providerStepsHelper.ApprovesTheCohortsAndSendsToEmployer();
        }


        [When(@"Provider adds an apprentices approves the cohort")]
        public void WhenProviderAddsAnApprenticesApprovesTheCohort()
        {
            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);
        }

        [When(@"Receiver edits and sends an approved cohort to the provider")]
        public void WhenReceiverEditsAndSendsAnApprovedCohortToTheProvider()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            _employerStepsHelper.OpenRejectedCohort()
                .SelectEditApprentice()
                .EditApprenticePreApprovalAndSubmit()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort();
        }

        [When(@"Receiver sends a cohort to the provider for review and approval")]
        public void WhenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            _objectContext.UpdateOrganisationName(_receiver);

            _employerStepsHelper.OpenRejectedCohort()
                .SelectContinueToApproval()
                .SubmitSendToTrainingProviderForReview()
                .SendInstructionsToProviderForCohortToBeReviewed();
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

            if (!(manageYourApprenticePage.CheckIfApprenticeExists()))
            {
                throw new Exception("Unable to find just approved Apprentices");
            }
        }

        private void LoginAsReceiver()
        {
            _objectContext.UpdateOrganisationName(_receiver);
            Login();
        }

        private void LoginAsSender()
        {
            _objectContext.UpdateOrganisationName(_sender);
            Login();
        }

        private void Login()
        {
            _homePage = _multipleAccountsLoginHelper.Login(_context.GetUser<TransfersUser>(), true);
        }
    }
}
