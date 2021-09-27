using NUnit.Framework;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransferMatchingSteps
    {

        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly TransferMatchingUser _transfersUser;
        private HomePage _homePage;
        private PledgeVerificationPage _pledgeVerificationPage;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransferMatchingUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
        }

        [Given(@"the Employer logins using existing Transfer Matching Account")]
        public void GivenTheEmployerLoginsUsingExistingTransferMatchingAccount() => Login(_transfersUser.OrganisationName);

        [Then(@"the Employer can create pledge using default criteria")]
        public void ThenTheEmployerCanCreatePledgeUsingDefaultCriteria()
        {
            var page = CreateATransferPledge(true);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(page.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(page.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(page.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(page.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeId();
        }

        [Then(@"the Employer can create anonymous pledge using non default criteria")]
        public void ThenTheEmployerCanCreateAnonymousPledgeUsingNonDefaultCriteria()
        {
            _pledgeVerificationPage = CreateATransferPledge(false)
                .GoToAddtheLocationPage().EnterLocation()
                .GoToChoosetheSectorPage().SelectSetorAndContinue()
                .GoToChooseTheTypesOfJobPage().SelectTypeOfJobAndContinue()
                .GoToChooseTheLevelPage().SelectLevelAndContinue()
                .ContinueToPledgeVerificationPage();

            SetPledgeId();
        }

        protected void SetPledgeId() => _pledgeVerificationPage.SetPledgeId();

        private CreateATransferPledgePage CreateATransferPledge(bool showOrgName)
        {
            return new HomePageFinancesSection_YourTransfers(_context)
                .NavigateToTransferMatchingPage()
                .GotoCreateTransfersPledgePage()
                .StartCreatePledge()
                .GoToPledgeAmountAndOptionPage()
                .CaptureAvailablePledgeAmount()
                .EnterAmountAndOrgName(showOrgName);
        }

        [Then(@"the Employer can view pledges")]
        public void ThenTheEmployerCanViewPledges() => _pledgeVerificationPage.ViewYourPledges().VerifyPledge();


        [Then(@"the Employer can view transfers")]
        public void ThenTheEmployerCanViewTransfers()
        {
            new HomePageFinancesSection_YourTransfers(_context)
                .NavigateToTransferMatchingPage()
                .GoToViewMyTransferPledgePage();
        }

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _homePage = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }
    }
}
