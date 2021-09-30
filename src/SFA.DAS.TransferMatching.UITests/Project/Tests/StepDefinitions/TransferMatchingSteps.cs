using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransferMatchingSteps
    {
        private readonly ScenarioContext _context;
        private readonly AccountSignOutHelper _accountSignOutHelper;
        private PledgeVerificationPage _pledgeVerificationPage;
        private ManageTransferMatchingPage _manageTransferMatchingPage;
        private MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransferMatchingUser _transferMatchingUser;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly string _sender;
        private readonly string _receiver;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _objectContext = context.Get<ObjectContext>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
            _transferMatchingUser = context.GetUser<TransferMatchingUser>();
            _sender = _transferMatchingUser.OrganisationName;
            _receiver = _transferMatchingUser.SecondOrganisationName;
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
        }

        [Then(@"the Employer can approve the application")]
        public void ThenTheEmployerCanApproveTheApplication()
        {
            _accountSignOutHelper.SignOut();

            _objectContext.UpdateOrganisationName(_sender);

            _multipleAccountsLoginHelper.ReLogin();

            NavigateToTransferMatchingPage();

            _objectContext.UpdateOrganisationName(_receiver);

            GoToViewMyTransferPledgePage().GoToTransferPledgePage().GoToApproveAppliationPage().ApproveApplication();
        }


        [When(@"the receiver applies for the pledge")]
        public void WhenTheReceiverAppliesForThePledge()
        {
            _accountSignOutHelper.SignOut();

            _tabHelper.OpenInNewTab(UrlConfig.TransferMacthingApplyUrl(_objectContext.GetPledgeId()));

            new TransferFundDetailsPage(_context).ApplyForTransferFunds();

            _objectContext.UpdateOrganisationName(_receiver);

            _multipleAccountsLoginHelper.LoginToMyAccountTransferFunding();

            new MyAccountTransferFundingPage(_context)
                .GoToCreateATransfersApplicationPage(_receiver)
                .GoToApprenticeshipTrainingPage()
                .EnterAppTrainingDetailsAndContinue()
                .GoToYourBusinessDetailsPage()
                .EnterBusinessDetailsAndContinue()
                .GoToAboutYourApprenticeshipPage()
                .EnterMoreDetailsAndContinue()
                .GoToContactDetailsPage()
                .EnterContactDetailsAndContinue()
                .SubmitApplication();
        }

        [Given(@"the Employer logins using existing Transfer Matching Account")]
        public void GivenTheEmployerLoginsUsingExistingTransferMatchingAccount()
        {
            var user = _context.GetUser<TransferMatchingUser>();

            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(_context, user)
            {
                OrganisationName = user.OrganisationName
            };

            _multipleAccountsLoginHelper.Login(user, true);
        }

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
        public void TheEmployerCanViewTransfers() => GoToViewMyTransferPledgePage();

        [Then(@"the user can not create transfer pledge")]
        public void ThenTheUserCanNotCreateTransferPledge() => Assert.AreEqual(false, NavigateToTransferMatchingPage().CanCreateTransferPledge(), "View user can create transfer pledge");

        private ManageTransferMatchingPage NavigateToTransferMatchingPage() => _manageTransferMatchingPage = new HomePageFinancesSection_YourTransfers(_context).NavigateToTransferMatchingPage();

        private MyTransferPledgesPage GoToViewMyTransferPledgePage() => _manageTransferMatchingPage.GoToViewMyTransferPledgePage();
    }
}
