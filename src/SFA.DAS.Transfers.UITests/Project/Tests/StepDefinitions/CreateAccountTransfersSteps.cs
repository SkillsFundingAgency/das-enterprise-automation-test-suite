using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;

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
            var datahelper = context.Get<RegistrationDataHelper>();
            _firstOrganisationName = datahelper.CompanyTypeOrg;
            _secondOrganisationName = datahelper.CompanyTypeOrg2;
            _thirdOrganisationName = datahelper.CompanyTypeOrg3;
        }

        [Given(@"We have (one|two|three) Employer accounts where none are a Transfer sender or Transfer Receiver")]
        public void GivenWehaveTwoEmployerAccountsWhereNeitherIsATransferSenderOrTransferReceiver(string number) => AccountsAreCreated(number);

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

                _secondAccountId = _objectContext.GetSecondAccountHashedId();
            }

            if (number == "three")
            {
                _objectContext.UpdateOrganisationName(_thirdOrganisationName);

                _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 2);

                _thirdAccountId = _objectContext.GetThirdAccountHashedId();
            }
        }

        [Given(@"We have (one|two|three) Employer accounts where the (First|Second|Third) is a Transfer sender and the (First|Second|Third) is a Transfer Receiver")]
        public void GivenWeHaveTwoEmployerAccountsWhereTheFirstIsATransferSenderAndTheSecondIsATransferReceiver(string number, string sender, string receiver)
        {
            AccountsAreCreated(number);

            (string senderOrganisationName, string senderAccountId, string senderPublicAccountId) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, string receiverPublicAccountId) = GetAccountDetails(receiver);

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
            (string senderOrganisationName, string senderAccountId, string senderPublicAccountId) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, string receiverPublicAccountId) = GetAccountDetails(receiver);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }

        [When(@"(First|Second|Third) account creates transfer request to (First|Second|Third) account and (First|Second|Third) account accepts the request")]
        public void WhenFirstAccountCreatesConnectionRequestToSecondAccountAndSecondAccountAcceptsTheRequest(string sender, string receiver, string acceptor)
        {
            if (receiver != acceptor) throw new ArgumentException("The acceptor must be the same as the reciever");

            (string senderOrganisationName, string senderAccountId, string senderPublicAccountId) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, string receiverPublicAccountId) = GetAccountDetails(receiver);

            SenderConnectsToReceiver(senderOrganisationName, receiverPublicAccountId);
            ReceiverAcceptsConnection(senderOrganisationName, receiverOrganisationName);
        }

        private (string, string, string) GetAccountDetails(string account)
        {
            return true switch
            {
                bool _ when (account == "First") => (_firstOrganisationName, _firstAccountId, _objectContext.GetPublicHashedAccountId()),
                bool _ when (account == "Second") => (_secondOrganisationName, _secondAccountId, _objectContext.GetSecondAccountPublicHashedId()),
                bool _ when (account == "Third") => (_thirdOrganisationName, _thirdAccountId, _objectContext.GetThirdAccountPublicHashedId()),
                _ => (string.Empty, string.Empty, string.Empty),
            };
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
            (string senderOrganisationName, string senderAccountId, string senderPublicAccountId) = GetAccountDetails(sender);
            (string receiverOrganisationName, string receiverAccountId, string receiverPublicAccountId) = GetAccountDetails(receiver);

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
