using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountTransfersSteps
    {
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private HomePage _homePage;

        private readonly Dictionary<string, (string orgName, string hashedAccountId, string publicHashedAccountId)> _accountDetails;

        public CreateAccountTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _approvalsStepsHelper = new ApprovalsStepsHelper(context);
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _accountDetails = new Dictionary<string, (string orgName, string hashedAccountId, string publicHashedAccountId)>();
        }

        [Given(@"We have (two|three) Employer accounts")]
        public void GivenWeHaveEmployerAccounts(string number) => AccountsAreCreated(number);

        [Given(@"(First|Second|Third) is a Sender connected to (First|Second|Third) as a Receiver")]
        public void GivenSenderIsConnectedToReceiver(string sender, string receiver) => SenderConnectsToReceiverAndReceiverAccepts(sender, receiver);

        [When(@"(First|Second|Third) account creates transfer request to (First|Second|Third) account and (First|Second|Third) account accepts the request")]
        public void WhenFirstAccountCreatesConnectionRequestToSecondAccountAndSecondAccountAcceptsTheRequest(string sender, string receiver, string acceptor)
        {
            if (receiver != acceptor) throw new ArgumentException("The acceptor must be the same as the reciever");

            SenderConnectsToReceiverAndReceiverAccepts(sender, receiver);
        }

        [Then(@"A transfer connection is established successfully between (First|Second|Third) account as Sender and (First|Second|Third) account as Receiver")]
        public void ThenATransferConnectionIsEstablishedSuccessfullyBetweenFirstAccountAsSenderAndSecondAccountAsReceiver(string sender, string receiver)
        {
            (string senderOrganisationName, string senderAccountId, _) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, _) = GetAccountDetails(receiver);

            _homePage = GoToHomePage(senderOrganisationName);

            bool senderAssertion = CheckTransferConnectionStatus(receiverOrganisationName);

            _homePage = GoToHomePage(receiverOrganisationName);

            bool receiverAssertion = CheckTransferConnectionStatus(senderOrganisationName);

            if (!senderAssertion)
                if (!receiverAssertion)
                    throw new Exception($"We don't have an approved transfers connection between {senderOrganisationName}({senderAccountId}) and {receiverOrganisationName}({receiverAccountId})");
        }

        private void AccountsAreCreated(string noOfAccounts)
        {
            _homePage = _approvalsStepsHelper.CreatesAccountAndSignAnAgreement();

            _homePage = AddNewAccountAndSignAnAgreement(_registrationDataHelper.CompanyTypeOrg2, 1);

            if (noOfAccounts == "three") _homePage = AddNewAccountAndSignAnAgreement(_registrationDataHelper.CompanyTypeOrg3, 2);

            SetAccountDetails(noOfAccounts);
        }

        private HomePage AddNewAccountAndSignAnAgreement(string orgName, int index)
        {
            UpdateOrganisationName(orgName);

            return _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, index);
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
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }


        private void SenderConnectsToReceiver(string senderOrganisationName, string publicReceiverAccountId)
        {
            // Sender connects to receiver 
            UpdateOrganisationName(senderOrganisationName);

            _homePage.GoToYourAccountsPage().GoToHomePage(senderOrganisationName);

            _homePage = OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(publicReceiverAccountId)
                .SendTransferConnectionRequest()
                .GoToHomePage();
        }

        private void ReceiverAcceptsConnection(string senderOrganisationName, string receiverOrganiationName)
        {
            UpdateOrganisationName(receiverOrganiationName);

            _homePage.GoToYourAccountsPage().GoToHomePage(receiverOrganiationName);

            _homePage = OpenTransfers().ViewTransferConnectionRequestDetails(senderOrganisationName).AcceptTransferConnectionRequest().GoToHomePage();
        }

        private HomePage GoToHomePage(string OrgName) { UpdateOrganisationName(OrgName); return _homePage.GoToYourAccountsPage().GoToHomePage(OrgName); }

        private bool CheckTransferConnectionStatus(string OrgName) => OpenTransfers().CheckTransferConnectionStatus(OrgName);

        private TransfersPage OpenTransfers() => new FinancePage(_context, true).OpenTransfers();

        private void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);
    }
}
