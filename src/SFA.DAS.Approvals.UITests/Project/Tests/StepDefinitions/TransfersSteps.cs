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


namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;
        private readonly DataHelper _dataHelper;
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
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
            _loginHelper = new MultipleAccountsLoginHelper(context);
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = _objectContext.GetDataHelper();
            _approvalsStepsHelper = new ApprovalsStepsHelper(context);
            _senderAccountId = null;
            _recieverAccountId = null;
        }

        [Given(@"We have a new Sender with sufficient levy funds and a new Receiver accounts setup")]
        public void GivenWeHaveANewSenderWithSufficientLevyFundsAndANewReceiverAccountsSetup()
        {
            _homePage = _approvalsStepsHelper.CreatesEmployerAccountAndSignAnAgreement();

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

        [Given(@"the Employer login using existing transfers account")]
        public void GivenTheEmployerLoginUsingExistingTransfersAccount()
        {
            _homePage = _loginHelper.Login(_context.GetUser<TransfersUser>(), true);
        }
    }
}
