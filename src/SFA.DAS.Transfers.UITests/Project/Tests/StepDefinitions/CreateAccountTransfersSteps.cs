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

        [Given(@"We have (one|two|three) Employer accounts")]
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

        private void AccountsAreCreated(string number)
        {
            if (number == "one" || number == "two" || number == "three")
            {
                _homePage = _approvalsStepsHelper.CreatesAccountAndSignAnAgreement();

                _firstAccountId = _objectContext.GetHashedAccountId();
            }

            if (number == "two" || number == "three")
            {
                UpdateOrganisationName(_secondOrganisationName);

                _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 1);

                _secondAccountId = _objectContext.GetSecondAccountHashedId();
            }

            if (number == "three")
            {
                UpdateOrganisationName(_thirdOrganisationName);

                _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 2);

                _thirdAccountId = _objectContext.GetThirdAccountHashedId();
            }
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
