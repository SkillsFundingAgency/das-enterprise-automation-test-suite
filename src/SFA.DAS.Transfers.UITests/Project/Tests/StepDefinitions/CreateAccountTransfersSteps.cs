using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountTransfersSteps
    {
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        private HomePage _homePage;
        private string _firstAccountId;
        private string _secondAccountId;
        private string _thirdAccountId;
        private readonly string _firstOrganisationName;
        private readonly string _secondOrganisationName;
        private readonly string _thirdOrganisationName;


        public CreateAccountTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _approvalsStepsHelper = new ApprovalsStepsHelper(context);
            _firstAccountId = null;
            _secondAccountId = null;
            _thirdAccountId = null;
            _firstOrganisationName = context.Get<RegistrationDataHelper>().CompanyTypeOrg;
            _secondOrganisationName = context.GetUser<TransfersUser>().SecondOrganisationName;
            _thirdOrganisationName = context.GetUser<TransfersUser>().ThirdOrganisationName;
        }

        [Given(@"We have (one|two|three) Employer accounts where none are a Transfer sender or Transfer Receiver")]
        public void GivenWehaveTwoEmployerAccountsWhereNeitherIsATransferSenderOrTransferReceiver(string number)
        {
            AccountsAreCreated(number);
        }

        private void AccountsAreCreated(string number)
        {            
            if (number == "one" || number == "two" || number == "three")
            {
                _homePage = _approvalsStepsHelper.CreatesAccountAndSignAnAgreement();

                _firstAccountId = _objectContext.GetHashedAccountId();
            }

            if (number == "two" || number == "three")
            {
                _objectContext.UpdateOrganisationName(_secondOrganisationName);

                _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 1);

                _secondAccountId = _objectContext.GetSecondHashedAccountId();
            }

            if (number == "three")
            {
                _objectContext.UpdateOrganisationName(_thirdOrganisationName);

                _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 2);

                _thirdAccountId = _objectContext.GetThirdHashedAccountId();
            }
        }

        [Given(@"We have (one|two|three) Employer accounts where the (First|Second|Third) is a Transfer sender and the (First|Second|Third) is a Transfer Receiver")]
        public void GivenWeHaveTwoEmployerAccountsWhereTheFirstIsATransferSenderAndTheSecondIsATransferReceiver(string number, string sender, string receiver)
        {
            AccountsAreCreated(number);

            GetAccountDetails(sender, out string senderOrganisationName, out string senderAccountId, out string senderPublicAccountId);
            GetAccountDetails(receiver, out string receiverOrganisationName, out string receiverAccountId, out string receiverPublicAccountId);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }

        [Given(@"We have (one|two|three) Employer accounts")]
        public void GivenWeHaveEmployerAccounts(string number)
        {
            AccountsAreCreated(number);
        }

        [Given(@"(First|Second|Third) is a Sender connected to (First|Second|Third) as a Receiver")]
        public void GivenSenderIsConnectedToReceiver(string sender, string receiver)
        {
            GetAccountDetails(sender, out string senderOrganisationName, out string senderAccountId, out string senderPublicAccountId);
            GetAccountDetails(receiver, out string receiverOrganisationName, out string receiverAccountId, out string receiverPublicAccountId);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }

        [When(@"(First|Second|Third) account creates transfer request to (First|Second|Third) account and (First|Second|Third) account accepts the request")]
        public void WhenFirstAccountCreatesConnectionRequestToSecondAccountAndSecondAccountAcceptsTheRequest(string sender, string receiver, string acceptor)
        {
            if (receiver != acceptor)
                throw new ArgumentException("The acceptor must be the same as the reciever");

            GetAccountDetails(sender, out string senderOrganisationName, out string senderAccountId, out string senderPublicAccountId);
            GetAccountDetails(receiver, out string receiverOrganisationName, out string receiverAccountId, out string receiverPublicAccountId);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }

        private void GetAccountDetails(string account, out string organisationName, out string accountId, out string publicAccountId)
        {
            switch (account)
            {
                case "First":
                    organisationName = _firstOrganisationName;
                    accountId = _firstAccountId;
                    publicAccountId = _objectContext.GetPublicHashedAccountId();
                    break;
                case "Second":
                    organisationName = _secondOrganisationName;
                    accountId = _secondAccountId;
                    publicAccountId = _objectContext.GetPublicSecondHashedAccountId();
                    break;
                case "Third":
                    organisationName = _thirdOrganisationName;
                    accountId = _thirdAccountId;
                    publicAccountId = _objectContext.GetPublicThirdHashedAccountId();
                    break;

                default:
                    organisationName = string.Empty;
                    accountId = string.Empty;
                    publicAccountId = string.Empty;
                    break;
            }
        }

        private void SenderConnectsToReceiver(string senderOrganisationName, string publicReceiverAccountId)
        {
            // Sender connects to receiver 
            _objectContext.UpdateOrganisationName(senderOrganisationName);
            _homePage.GoToYourAccountsPage()
              .GoToHomePage(senderOrganisationName);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(publicReceiverAccountId)
                .SendTransferConnectionRequest()
                .GoToHomePage();
        }

        private void ReceiverAcceptsConnection(string senderOrganisationName, string receiverOrganiationName)
        {
            _objectContext.UpdateOrganisationName(receiverOrganiationName);
            _homePage.GoToYourAccountsPage()
                 .GoToHomePage(receiverOrganiationName);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ViewTransferConnectionRequestDetails(senderOrganisationName)
                .AcceptTransferConnectionRequest()
                .GoToHomePage();
        }

        [Then(@"A transfer connection is established successfully between (First|Second|Third) account as Sender and (First|Second|Third) account as Receiver")]
        public void ThenATransferConnectionIsEstablishedSuccessfullyBetweenFirstAccountAsSenderAndSecondAccountAsReceiver(string sender, string receiver)
        {
            GetAccountDetails(sender, out string senderOrganisationName, out string senderAccountId, out string senderPublicAccountId);
            GetAccountDetails(receiver, out string receiverOrganisationName, out string receiverAccountId, out string receiverPublicAccountId);

            _objectContext.UpdateOrganisationName(senderOrganisationName);
            _homePage.GoToYourAccountsPage()
                .GoToHomePage(senderOrganisationName);

            bool senderAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(receiverOrganisationName);

            _objectContext.UpdateOrganisationName(receiverOrganisationName);
            _homePage.GoToYourAccountsPage()
                .GoToHomePage(receiverOrganisationName);

            bool receiverAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(senderOrganisationName);

            if (!senderAssertion)
                if (!receiverAssertion)
                    throw new Exception($"We don't have an approved transfers connection between {senderOrganisationName}({senderAccountId}) and {receiverOrganisationName}({receiverAccountId})");
        }
    }
}
