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
        private HomePage _homePage;
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
            _recieverAccountId = null;
        }

        [Given(@"the Employer has sufficient levy declarations for transfers")]
        public void GivenTheEmployerHasSufficientLevyDeclarationsForTransfers()
        {
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("18-19", "10", "72000", "99000", "2019-01-15");
            table.AddRow("18-19", "11", "82000", "99000", "2019-02-15");
            table.AddRow("18-19", "12", "92000", "99000", "2019-03-15");
            _mongoDbGenerator.AddLevyDeclarations(1.00m, new DateTime(2019, 01, 15), table);
            _loginCredentialsHelper.SetIsLevy();
        }

        [Given(@"the Employer login using existing transfers account")]
        public void GivenTheEmployerLoginUsingExistingTransfersAccount()
        {
            _homePage = _loginHelper.Login(_context.GetUser<TransfersUser>(), true);
        }


        [Given(@"the User adds Receiver Employer account and sign an agreement")]
        public void GivenTheUserAddsReceiverEmployerAccountAndSignAnAgreement()
        {
            _objectContext.UpdateDataHelper(new DataHelper(_dataHelper.TwoDigitProjectCode));

            _mongoDbGenerator.AddGatewayUsers();

            _objectContext.UpdateOrganisationName(_transfersConfig.AP_ReceiverOrganisationName);

            _homePage = _homePage.GoToYourAccountsPage()
                .AddNewAccount()
                .ContinueToGGSignIn()
                .SignInTo()
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage()
                .ContinueWithAgreement()
                .SignAgreement();

            _recieverAccountId = _homePage.AccountId();
            _objectContext.SetReceiverAccountId(_recieverAccountId);

            _homePage.GoToYourAccountsPage()
                .GoToHomePage(_projectConfig.RE_OrganisationName);
        }

        [When(@"the Employer connects to receiving employer")]
        public void WhenTheEmployerConnectsToReceivingEmployer()
        {
            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ConnectWithReceivingEmployer()
                .ContinueToConnectWithReceiver()
                .ConnectWithReceivingEmployer(_recieverAccountId)
                .SendTransferConnectionRequest()
                .GoToHomePage();

            _homePage.GoToYourAccountsPage()
                 .GoToHomePage(_transfersConfig.AP_ReceiverOrganisationName);

            _homePage = new FinancePage(_context, true)
                .OpenTransfers()
                .ViewTransferConnectionRequestDetails()
                .AcceptTransferConnectionRequest()
                .GoToHomePage();
        }

        [Then(@"A connection between sender and receiver is established successfully")]
        public void ThenAConnectionBetweenSenderAndReceiverIsEstablishedSuccessfully()
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
                    throw new Exception($"We don't have an approved transfers connection between {sender}({_objectContext.GetAccountId()}) and {receiver}({_recieverAccountId})");
        }
    }
}
