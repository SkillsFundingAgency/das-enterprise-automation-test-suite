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
        private readonly ProjectConfig _projectConfig;
        private readonly TransfersConfig _transfersConfig;
        private readonly MongoDbDataGenerator _mongoDbGenerator;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;
        private readonly MultipleAccountsLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;
        private readonly DataHelper _dataHelper;
        private readonly ApprovalsStepsHelper _approvalsStepsHelper;
        private HomePage _homePage;
        private string _senderAccountId;
        private string _recieverAccountId;

        public TransfersSteps(ScenarioContext context)
        {
            _context = context;
            _projectConfig = context.GetProjectConfig<ProjectConfig>();
            _transfersConfig = context.GetTransfersConfig<TransfersConfig>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _mongoDbGenerator = new MongoDbDataGenerator(_context);
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
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("18-19", "10", "72000", "99000", "2019-01-15");
            table.AddRow("18-19", "11", "82000", "99000", "2019-02-15");
            table.AddRow("18-19", "12", "92000", "99000", "2019-03-15");
            _mongoDbGenerator.AddLevyDeclarations(1.00m, new DateTime(2019, 01, 15), table);
            _loginCredentialsHelper.SetIsLevy();

            _homePage = _approvalsStepsHelper.CreatesEmployerAccountAndSignAnAgreement();

            _senderAccountId = _objectContext.GetAccountId();

            _objectContext.UpdateDataHelper(new DataHelper(_dataHelper.TwoDigitProjectCode));

            _mongoDbGenerator.AddGatewayUsers();

            _objectContext.UpdateOrganisationName(_transfersConfig.AP_ReceiverOrganisationName);

            _homePage = _approvalsStepsHelper.AddNewAccountAndSignAnAgreement(_homePage);

            _recieverAccountId = _objectContext.GetReceiverAccountId();
        }

        [When(@"Sender connects to Receiver")]
        public void WhenSenderConnectsToReceiver()
        {
            //Sender connects to receiver 
            _homePage.GoToYourAccountsPage()
              .GoToHomePage(_projectConfig.RE_OrganisationName);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(_recieverAccountId)
                .SendTransferConnectionRequest()
                .GoToHomePage();

            //Receiver accepts the conneciton
            _homePage.GoToYourAccountsPage()
                 .GoToHomePage(_transfersConfig.AP_ReceiverOrganisationName);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ViewTransferConnectionRequestDetails()
                .AcceptTransferConnectionRequest()
                .GoToHomePage();
        }

        [Then(@"A transfer connection is established successfully")]
        public void ThenATransferConnectionIsEstablishedSuccessfully()
        {
            string sender = _projectConfig.RE_OrganisationName;
            string receiver = _transfersConfig.AP_ReceiverOrganisationName;

            _homePage.GoToYourAccountsPage()
                .GoToHomePage(sender);

            bool senderAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(receiver);

            _homePage.GoToYourAccountsPage()
                .GoToHomePage(receiver);

            bool receiverAssertion = new FinancePage(_context, true)
               .OpenTransfers()
               .CheckTransferConnectionStatus(sender);

            if (!senderAssertion)
                if (!receiverAssertion)
                    throw new Exception($"We don't have an approved transfers connection between {sender}({_senderAccountId}) and {receiver}({_recieverAccountId})");
        }


        [Given(@"the Employer login using existing transfers account")]
        public void GivenTheEmployerLoginUsingExistingTransfersAccount()
        {
            _homePage = _loginHelper.Login(_context.GetUser<TransfersUser>(), true);
        }
    }
}
