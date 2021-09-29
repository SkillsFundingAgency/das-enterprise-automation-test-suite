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
        private ManageTransferMatchingPage _manageTransferMatchingPage;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransferMatchingUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
        }

        [Given(@"the Employer logins using existing Transfer Matching Account")]
        public void GivenTheEmployerLoginsUsingExistingTransferMatchingAccount() => Login(_context.GetUser<TransferMatchingUser>());

        [Then(@"the Employer cannot exceed the maximum funding available")]
        public void ThenTheEmployerCannotExceedTheMaximumFundingAvailable()
        {
            string errorMessage = GoToEnterPlegeAmountPage().EnterMoreThanAvailableFunding().GetErrorMessage();

            Assert.Multiple(() => 
            {
                StringAssert.Contains("There is a problem", errorMessage);

                StringAssert.Contains("Enter a number between", errorMessage);
            });
        }


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

        private CreateATransferPledgePage CreateATransferPledge(bool showOrgName) => GoToEnterPlegeAmountPage().EnterAmountAndOrgName(showOrgName);

        private PledgeAmountAndOptionToHideOrganisastionNamePage GoToEnterPlegeAmountPage()
        {
            return NavigateToTransferMatchingPage()
                .GotoCreateTransfersPledgePage()
                .StartCreatePledge()
                .GoToPledgeAmountAndOptionPage()
                .CaptureAvailablePledgeAmount();
        }

        [Then(@"the Employer can view pledges from verification page")]
        public void ThenTheEmployerCanViewPledges() => _pledgeVerificationPage.ViewYourPledges().VerifyPledge();

        [Then(@"the user can view transfer pledge")]
        public void ThenTheEmployerCanViewTransfers() => _manageTransferMatchingPage.GoToViewMyTransferPledgePage();

        [Then(@"the user can not create transfer pledge")]
        public void ThenTheUserCanNotCreateTransferPledge() => Assert.AreEqual(false, NavigateToTransferMatchingPage().CanCreateTransferPledge(), "View user can create transfer pledge");

        private ManageTransferMatchingPage NavigateToTransferMatchingPage() => _manageTransferMatchingPage = new HomePageFinancesSection_YourTransfers(_context).NavigateToTransferMatchingPage();

        private void Login(MultipleAccountUser user)
        {
            _multipleAccountsLoginHelper.OrganisationName = user.OrganisationName;

            _homePage = _multipleAccountsLoginHelper.Login(user, true);
        }
    }
}
