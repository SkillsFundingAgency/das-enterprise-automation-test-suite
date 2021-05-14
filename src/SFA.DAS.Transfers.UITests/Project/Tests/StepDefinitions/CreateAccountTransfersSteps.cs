using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountTransfersSteps
    {
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        private HomePage _homePage;
        private string _senderAccountId;
        private string _recieverAccountId;
        private readonly string _sender;
        private readonly string _receiver;


        public CreateAccountTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _approvalsStepsHelper = new ApprovalsStepsHelper(context);
            _senderAccountId = null;
            _recieverAccountId = null;
            _sender = context.GetRegistrationConfig<RegistrationConfig>().RE_OrganisationName;
            _receiver = context.GetUser<TransfersUser>().SecondOrganisationName;
        }

        [Given(@"We have a new Sender with sufficient levy funds and a new Receiver accounts setup")]
        public void GivenWeHaveANewSenderWithSufficientLevyFundsAndANewReceiverAccountsSetup()
        {
            _homePage = _approvalsStepsHelper.CreatesAccountAndSignAnAgreement();

            _senderAccountId = _objectContext.GetAccountId();

            _objectContext.UpdateOrganisationName(_receiver);

            _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage, 1);

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
    }
}
