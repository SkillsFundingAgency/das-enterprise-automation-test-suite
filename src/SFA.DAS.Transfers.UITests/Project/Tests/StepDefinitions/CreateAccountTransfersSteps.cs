using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountTransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private readonly TransferEmployerStepsHelper _employerStepsHelper;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly TransfersCreateCohortStepsHelper _transfersCreateCohortStepsHelper;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper;

        private readonly Dictionary<string, (string orgName, string hashedAccountId, string publicHashedAccountId)> _accountDetails;
        private HomePage _homePage;

        public CreateAccountTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();

            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
            _employerStepsHelper = new TransferEmployerStepsHelper(context);
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
            _transfersCreateCohortStepsHelper = new TransfersCreateCohortStepsHelper(context);
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _providerApproveStepsHelper = new ProviderApproveStepsHelper(context);

            _accountDetails = new Dictionary<string, (string orgName, string hashedAccountId, string publicHashedAccountId)>();
        }

        [Given(@"We have (two|three) Employer accounts")]
        public void GivenWeHaveEmployerAccounts(string number) => AccountsAreCreated(number);

        [Given(@"(First|Second|Third) is a Sender connected to (First|Second|Third) as a Receiver")]
        public void GivenSenderIsConnectedToReceiver(string sender, string receiver)
        {
            SenderConnectsToReceiverAndReceiverAccepts(sender, receiver);
        }

        [When(@"(First|Second|Third) account creates transfer request to (First|Second|Third) account and (First|Second|Third) account accepts the request")]
        public void WhenFirstAccountCreatesConnectionRequestToSecondAccountAndSecondAccountAcceptsTheRequest(string sender, string receiver, string acceptor)
        {
            if (receiver != acceptor) throw new ArgumentException("The acceptor must be the same as the reciever");

            SenderConnectsToReceiverAndReceiverAccepts(sender, receiver);
        }

        [When(@"(First|Second|Third) account creates a transfer connection request to (First|Second|Third) account")]
        public void WhenSenderAccountCreatesTransferConnectionRequestToReceiverAccount(string sender, string receiver)
        {
            SenderConnectsToReceiver(GetAccountDetails(sender).orgName, GetAccountDetails(receiver).publicHashedAccountId);
        }

        [When(@"(First|Second|Third) account accepts the transfer connection request from (First|Second|Third) account")]
        public void WhenReceiverAccountAcceptsTheTransferConnectionRequest(string receiver, string sender)
        {
            ReceiverAcceptsConnection(GetAccountDetails(receiver).orgName, GetAccountDetails(sender).orgName);
        }

        [Then(@"A transfer connection is established successfully between (First|Second|Third) account as Sender and (First|Second|Third) account as Receiver")]
        public void ThenATransferConnectionIsEstablishedSuccessfullyBetweenFirstAccountAsSenderAndSecondAccountAsReceiver(string sender, string receiver)
        {
            (string senderOrganisationName, string senderAccountId, _) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, _) = GetAccountDetails(receiver);

            _homePage = GoToHomePage(senderOrganisationName);

            bool senderAssertion = CheckTransferConnectionStatus(receiverOrganisationName, "send");

            _homePage = GoToHomePage(receiverOrganisationName);

            bool receiverAssertion = CheckTransferConnectionStatus(senderOrganisationName, "receive");

            if (!senderAssertion || !receiverAssertion)
            {
                throw new Exception($"We don't have an approved transfers connection between {senderOrganisationName}({senderAccountId}) and {receiverOrganisationName}({receiverAccountId})");
            }
        }

        [When(@"Receiver (First|Second|Third) sends empty cohort using transfer funds from Sender (First|Second|Third) to the provider for review and approval")]
        public void GivenReceiverSendsACohortToTheProviderForReviewAndApproval(string receiver, string sender)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _transfersCreateCohortStepsHelper.EmployerCreateCohortAndSendsToProvider();
        }

        [When(@"Receiver (First|Second|Third) sends approved cohort using transfer funds from Sender (First|Second|Third) with (.*) apprentices to the provider for review and approval")]
        public void GivenReceiverSendsACohortToTheProviderForReviewAndApproval(string receiver, string sender, int numberOfApprentices)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);
            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        [When(@"Provider adds an apprentice and approves the cohort")]
        public void WhenProviderAddsAnApprenticesApprovesTheCohort() => _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

        [When(@"Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerApproveStepsHelper.EditAndApprove();

        [When(@"Receiver (First|Second|Third) approves the cohort")]
        public void WhenReceiverApprovesTheCohort(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _employerStepsHelper.Approve();
        }

        [When(@"Sender (First|Second|Third) approves the cohort")]
        public void WhenSenderApprovesTheCohort(string sender)
        {
            UpdateOrganisationName(GetAccountDetails(sender).orgName);
            _transfersCreateCohortStepsHelper.ApproveTransfersRequest();
        }

        [When(@"Sender (First|Second|Third) rejects the cohort")]
        public void WhenSenderRejectsTheCohort(string sender)
        {
            UpdateOrganisationName(GetAccountDetails(sender).orgName);
            _transfersCreateCohortStepsHelper.RejectTransfersRequest();
        }

        [Then(@"Receiver (First|Second|Third) sees the cohort in With transfer sending employers with status of (.*)")]
        public void ThenTheCohortIsInWithTransferSendingEmployersWithStatus(string receiver, string status)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _transfersCreateCohortStepsHelper.ValidateWithTransferSendingEmployersCohortStatus(status);
        }

        [Then(@"Receiver (First|Second|Third) sees the cohort in Ready to review with status of (.*)")]
        public void ThenTheCohortIsInReadyToReviewWithStatus(string receiver, string status)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _transfersCreateCohortStepsHelper.ValidateReadyToReviewCohortStatus(status);
        }

        [When(@"Receiver (First|Second|Third) edits and sends an approved cohort to the provider")]
        public void WhenReceiverEditsAndSendsAnApprovedCohortToTheProvider(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);

            _transfersCreateCohortStepsHelper.OpenRejectedCohort()
                .SelectEditApprentice()
                .EditApprenticePreApprovalAndSubmit()
                .EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [When(@"Receiver (First|Second|Third) sends a cohort to the provider for review and approval")]
        public void WhenReceiverSendsACohortToTheProviderForReviewAndApproval(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _transfersCreateCohortStepsHelper.OpenRejectedCohort().EmployerSendsToTrainingProviderForReview();
        }

        [Then(@"Receiver (First|Second|Third) has a new live apprenticeship record created")]
        public void ThenVerifyReceiverHasANewLiveApprenticeshipRecordCreated(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);

            var manageYourApprenticePage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }

        [Then(@"Receiver (First|Second|Third) has '(.*) apprentice change to review' task link")]
        [Then(@"Receiver (First|Second|Third) has '(.*) apprentice changes to review' task link")]
        public void ThenApprenticeChangeToReviewTaskLinkIsDisplayedUnderTasksPaneForTheReceiverAccount(string receiver, int numberOfTasks)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _employerStepsHelper.VerifyApprenticeChangeToReviewTaskLink(numberOfTasks);
        }

        [Then(@"Receiver (First|Second|Third) has no '... apprentice change\(s\) to review' task link")]
        public void ThenNoApprenticeChangeToReviewTaskLinkIsDisplayedUnderTasksPaneForTheReceiverAccount(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _employerStepsHelper.VerifyApprenticeChangeToReviewTaskLink(0);
        }

        [Then(@"Receiver (First|Second|Third) has '(.*) cohort request ready for approval' task link")]
        [Then(@"Receiver (First|Second|Third) has '(.*) cohort requests ready for approval' task link")]
        public void ThenCohortRequestReadyForApprovalTaskLinkIsDisplayedUnderTasksPaneForTheReceiverAccount(string receiver, int numberOfTasks)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _employerStepsHelper.VerifyCohortRequestReadyForApprovalTaskLink(numberOfTasks);
        }

        [Then(@"Receiver (First|Second|Third) has no '... cohort request\(s\) ready for approval' task link")]
        public void ThenNoCohortRequestReadyForApprovalTaskLinkIsDisplayedUnderTasksPaneForTheReceiverAccount(string receiver)
        {
            UpdateOrganisationName(GetAccountDetails(receiver).orgName);
            _employerStepsHelper.VerifyCohortRequestReadyForApprovalTaskLink(0);
        }

        [Then(@"(First|Second|Third) account has '(.*) connection request to review' task link")]
        [Then(@"(First|Second|Third) account has '(.*) connection requests to review' task link")]
        public void ThenConnectionRequestsToReviewTaskLinkIsDisplayedUnderTasksPaneForTheAccount(string account, int numberOfTasks)
        {
            UpdateOrganisationName(GetAccountDetails(account).orgName);
            _employerStepsHelper.VerifyReviewConnectionRequestTaskLink(numberOfTasks);
        }

        [Then(@"(First|Second|Third) account has no '... connection'")]
        [Then(@"(First|Second|Third) account has no '... connection request\(s\) to review' task link")]
        public void ThenNoConnectionRequestsToReviewTaskLinksIsDisplayedUnderTasksPaneForTheAccount(string account)
        {
            UpdateOrganisationName(GetAccountDetails(account).orgName);
            _employerStepsHelper.VerifyReviewConnectionRequestTaskLink(0);
        }

        [Then(@"'Transfer request received' task link is displayed under Tasks pane for the Sender (First|Second|Third) account")]
        public void ThenTransferRequestsReceivedTaskLinkIsDisplayedUnderTasksPaneForTheSenderAccount(string sender)
        {
            UpdateOrganisationName(GetAccountDetails(sender).orgName);
            _employerStepsHelper.VerifyTransferRequestReceivedTaskLink(1);
        }

        [Then(@"No 'Transfer request received' task link is displayed under Tasks pane for the Sender (First|Second|Third) account")]
        public void ThenNoTransferRequestsReceivedTaskLinkIsDisplayedUnderTasksPaneForTheSenderAccount(string sender)
        {
            UpdateOrganisationName(GetAccountDetails(sender).orgName);
            _employerStepsHelper.VerifyTransferRequestReceivedTaskLink(0);
        }

        [When(@"Provider approves the cohort and sends to recevier for approval")]
        public void WhenProviderApprovesTheCohortAndSendsToRecevierForApproval() => _providerStepsHelper.ApprovesTheCohortsAndSendsToEmployer();

        [When(@"Provider edits the apprentice Name")]
        public void WhenProviderEditsTheApprenticeName() => _providerStepsHelper.EditApprentice();

        private void AccountsAreCreated(string noOfAccounts)
        {
            var integers = new Dictionary<string, int> { { "one", 1 }, { "two", 2 }, { "three", 3 } };

            if (!integers.ContainsKey(noOfAccounts)) throw new Exception("Only one to three accounts are supported.");

            _homePage = _accountCreationStepsHelper.CreateUserAccount();

            if(integers[noOfAccounts] > 1)
            {
                _homePage = AddNewAccount(_registrationDataHelper.CompanyTypeOrg2, 1);
            }

            if (integers[noOfAccounts] > 2)
            {
                _homePage = AddNewAccount(_registrationDataHelper.CompanyTypeOrg3, 2);
            }

            SetAccountDetails(noOfAccounts);
        }

        private HomePage AddNewAccount(string orgName, int index)
        {
            UpdateOrganisationName(orgName);

            return _accountCreationStepsHelper.AddNewAccount(_homePage, index);
        }

        private void SetAccountDetails(string noOfAccounts)
        {
            var accountDetails = _registrationSqlDataHelper.CollectAccountDetails(_objectContext.GetRegisteredEmail());

            _accountDetails.Add("First", (accountDetails[0].orgName, accountDetails[0].hashedId, accountDetails[0].publicHashedId));
            _accountDetails.Add("Second", (accountDetails[1].orgName, accountDetails[1].hashedId, accountDetails[1].publicHashedId));

            if (noOfAccounts == "three") _accountDetails.Add("Third", (accountDetails[2].orgName, accountDetails[2].hashedId, accountDetails[2].publicHashedId));
        }

        private (string orgName, string hashedAccountId, string publicHashedAccountId) GetAccountDetails(string account) => _accountDetails.GetValueOrDefault(account);

        private void SenderConnectsToReceiverAndReceiverAccepts(string sender, string receiver)
        {
            (string senderOrganisationName, _, _) = GetAccountDetails(sender);
            (string receiverOrganisationName, _, string receiverPublicAccountId) = GetAccountDetails(receiver);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(receiverOrganisationName, senderOrganisationName);
        }

        private void SenderConnectsToReceiver(string senderOrganisationName, string publicReceiverAccountId)
        {
            _objectContext.ReplaceTransferSenderOrganisationName(senderOrganisationName);
            _homePage = GoToHomePage(senderOrganisationName);

            _homePage = OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(publicReceiverAccountId)
                .SendTransferConnectionRequest()
                .GoToHomePage();
        }

        private void ReceiverAcceptsConnection(string receiverOrganiationName, string senderOrganisationName)
        {
            _objectContext.ReplaceTransferReceiverOrganisationName(receiverOrganiationName);
            _homePage = GoToHomePage(receiverOrganiationName);
            _homePage = OpenTransfers().ViewTransferConnectionRequestDetails(senderOrganisationName).AcceptTransferConnectionRequest().GoToHomePage();
        }

        private HomePage GoToHomePage(string orgName) { UpdateOrganisationName(orgName); return _homePage.GoToYourAccountsPage().GoToHomePage(orgName); }

        private bool CheckTransferConnectionStatus(string orgName, string role) => OpenTransfers().CheckTransferConnectionStatus(orgName, role);

        private TransfersPage OpenTransfers() => new FinancePage(_context, true).OpenTransfers();

        private void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);
    }
}
