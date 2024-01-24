using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly TransfersUser _transfersUser;
        private HomePage _homePage;

        private readonly string _sender;

        public TransfersSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransfersUser>();
            _sender = _transfersUser.OrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"We have a Sender with sufficient levy funds")]
        public void GivenWeHaveASenderWithSufficientLevyFunds() => Login(_sender);

        [Given(@"We have a Sender with sufficient levy funds without signing an agreement")]
        public void GivenWeHaveASenderWithSufficientLevyFundsWithoutSigningAnAgreement()
        {
            _homePage = _employerPortalLoginHelper.Login(_context.GetUser<AgreementNotSignedTransfersUser>(), true);
        }

        [Then(@"the sender transfer status is (disabled|enabled)")]
        public void CheckTheSenderTransferStatus(string expectedtransferStatus) => _homePage.GoToYourOrganisationsAndAgreementsPage().VerifyTransfersStatus(expectedtransferStatus);

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _homePage = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }
    }
}