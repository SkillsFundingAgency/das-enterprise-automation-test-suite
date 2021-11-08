using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using MyAccountTransferFundingPage = SFA.DAS.TransferMatching.UITests.Project.Tests.Pages.MyAccountTransferFundingPage;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Project.Helpers;

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
        private readonly EmployerLoginFromCreateAcccountPageHelper _loginFromCreateAcccountPageHelper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private string _sender;
        private string _receiver;
        private bool _isAnonymousPledge;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _objectContext = context.Get<ObjectContext>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
            _isAnonymousPledge = false;
            _loginFromCreateAcccountPageHelper = new EmployerLoginFromCreateAcccountPageHelper(_context);
        }

        [Given(@"the levy employer who are currently sending transfer funds login")]
        public void GivenTheLevyEmployerWhoAreCurrentlySendingTransferFundsLogin() => LoginAsSender(_context.GetUser<TransfersUser>());

        [Given(@"the levy employer who are not currently sending transfer funds login")]
        public void GivenTheLevyEmployerWhoAreNotCurrentlySendingTransferFundsLogin() => LoginAsSender(_context.GetUser<TransfersUserNoFunds>());

        [Then(@"the levy employer can apply for transfer opportunities")]
        public void ThenTheLevyEmployerCanApplyForTransferOpportunities() => NavigateToTransferMatchingPage().GoToFindABusinessPage();


        [Given(@"the another levy employer creates a pledge")]
        public void GivenTheAnotherLevyEmployerCreatesAPledge()
        {
            SignOut();

            CreateATransferPledge(_context.GetUser<TransactorUser>());
        }

        [Given(@"the levy employer creates a pledge")]
        public void GivenTheLevyEmployerCreatesAPledge() => CreateATransferPledge(_context.GetUser<LevyUser>());

        [Given(@"the levy employer login using existing transactor user account")]
        public void GivenTheEmployerLoginsUsingExistingTransactorUserAccount() => LoginAsSender(_context.GetUser<TransactorUser>());

        [When(@"the receiver levy employer applies for the pledge")]
        public void WhenTheReceiverLevyEmployerAppliesForThePledge() => ApplyForAPledge(_context.GetUser<LevyUser>());

        [Then(@"the non levy employer can apply for the pledge")]
        [When(@"the non levy employer applies for the pledge")]
        public void WhenTheNonLevyEmployerAppliesForThePledge() => ApplyForAPledge(_context.GetUser<NonLevyUser>());

        [Then(@"the non levy employer cannot exceed the available pledge funding")]
        public void ThenTheNonLevyEmployerCannotExceedTheAvailablePledgeFunding() 
            => AssertErrorMessage(ApplyForAnInvalidPledge(_context.GetUser<NonLevyUser>()).EnterAmountMoreThanAvailableFunding(), "There is not enough funding to support this many apprentices");

        [Then(@"the levy employer can approve the application")]
        public void ThenTheLevyEmployerCanApproveTheApplication()
        {
            _accountSignOutHelper.SignOut();

            _objectContext.UpdateOrganisationName(_sender);

            _multipleAccountsLoginHelper.ReLogin();

            NavigateToTransferMatchingPage();

            _objectContext.UpdateOrganisationName(_receiver);

            GoToViewMyTransferPledgePage().GoToTransferPledgePage().GoToApproveAppliationPage().ApproveApplication();
        }

        [Then(@"the non levy employer can accept funding")]
        public void ThenTheNonLevyEmployerCanAcceptFunding()
        {
            _objectContext.UpdateOrganisationName(_sender);

            _accountSignOutHelper.SignOut();

            LoginAsReceiver(_context.Get<NonLevyUser>(), false);

            NavigateToTransferMatchingPage()
                .ViewApplicationsIhaveSubmitted()
                .OpenPledgeApplication("APPROVED, AWAITING YOUR ACCEPTANCE")
                .VerifyAgreeToTermsIsMandatoryAndAcceptFunding()
                .ViewMyApplications()
                .OpenPledgeApplication("FUNDS AVAILABLE");
        }

        [Then(@"the pledge is available to apply")]
        public void ThenThePledgeIsAvailableToApply() => ApplyForTransferFunds();

        [When(@"the transfer receiver applies for the pledge")]
        public void TheTransferReceiverAppliesForThePledge()
        {
            var signInPage = ApplyForTransferFunds();

            _objectContext.UpdateOrganisationName(_receiver);

            _multipleAccountsLoginHelper.LoginToMyAccountTransferFunding(signInPage);

            SubmitApplication(new MyAccountTransferFundingPage(_context).GoToCreateATransfersApplicationPage(_receiver));
        }

        [Given(@"the levy employer logins using existing transfer matching account")]
        public void TheLevyEmployerLoginsUsingExistingTransferMatchingAccount() => LoginAsSender(_context.GetUser<TransferMatchingUser>());

        [Then(@"the levy employer cannot exceed the maximum funding available")]
        public void TheLevyEmployerCannotExceedTheMaximumFundingAvailable() => AssertErrorMessage(GoToEnterPlegeAmountPage().EnterInValidAmount(), "Enter a number between");

        [Then(@"the levy employer can create pledge using default criteria")]
        public void TheLevyEmployerCanCreatePledgeUsingDefaultCriteria()
        {
            var page = CreateATransferPledge(true);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(page.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(page.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(page.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(page.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }

        [Then(@"the levy employer can create anonymous pledge using non default criteria")]
        public void TheLevyEmployerCanCreateAnonymousPledgeUsingNonDefaultCriteria()
        {
            _isAnonymousPledge = true;

           _pledgeVerificationPage = CreateATransferPledge(false)
                .GoToAddtheLocationPage().EnterLocation()
                .GoToChoosetheSectorPage().SelectSetorAndContinue()
                .GoToChooseTheTypesOfJobPage().SelectTypeOfJobAndContinue()
                .GoToChooseTheLevelPage().SelectLevelAndContinue()
                .ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }

        [Then(@"the levy employer can view pledges from verification page")]
        public void TheLevyEmployerCanViewPledgesFromVerificationPage() => _pledgeVerificationPage.ViewYourPledges().VerifyPledge();

        [Then(@"the user can view transfer pledge")]
        public void TheEmployerCanViewTransfers() => GoToViewMyTransferPledgePage();

        [Then(@"the levy employer currently receiving funds can not create pledge")]
        public void ThenTheLevyEmployerCurrentlyReceivingFundsCanNotCreatePledge()
        {
            new HomePage(_context, true).GoToYourAccountsPage().ClickAccountLink(_receiver);

            TheUserCanNotCreateTransferPledge();
        }

        [Then(@"the user can not create transfer pledge")]
        public void TheUserCanNotCreateTransferPledge() => Assert.AreEqual(false, NavigateToTransferMatchingPage().CanCreateTransferPledge(), "User can create transfer pledge");

        [Then(@"the levy employer can not apply for transfer opportunities")]
        public void ThenTheLevyEmployerCanNotApplyForTransferOpportunities() => Assert.AreEqual(false, NavigateToTransferMatchingPage().CanApplyForTransferOppurtunity(), "User can apply for transfer oppurtunity");

        protected void SetPledgeDetail() => _pledgeVerificationPage.SetPledgeDetail();

        private CreateATransferPledgePage CreateATransferPledge(bool showOrgName) => GoToEnterPlegeAmountPage().EnterValidAmountAndOrgName(showOrgName);

        private PledgeAmountAndOptionToHideOrganisastionNamePage GoToEnterPlegeAmountPage()
        {
            return NavigateToTransferMatchingPage()
                .GotoCreateTransfersPledgePage()
                .StartCreatePledge()
                .GoToPledgeAmountAndOptionPage()
                .CaptureAvailablePledgeAmount();
        }

        private ManageTransferMatchingPage NavigateToTransferMatchingPage() => _manageTransferMatchingPage = new HomePageFinancesSection_YourTransfers(_context).NavigateToTransferMatchingPage();

        private MyTransferPledgesPage GoToViewMyTransferPledgePage() => _manageTransferMatchingPage.GoToViewMyTransferPledgePage();

        private void GoToTransferMacthingApplyUrl()
        {
            SignOut();

            _tabHelper.OpenInNewTab(UrlConfig.TransferMacthingApplyUrl(_objectContext.GetPledgeDetail().PledgeId));
        }

        private void SignOut() => _accountSignOutHelper.SignOut();

        private ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage(CreateATransfersApplicationPage page) => page.GoToApprenticeshipTrainingPage();

        private ApplicationsDetailsPage SubmitApplication(CreateATransfersApplicationPage page)
        {
            GoToApprenticeshipTrainingPage(page)
                .EnterAppTrainingDetailsAndContinue()
                .GoToYourBusinessDetailsPage()
                .EnterBusinessDetailsAndContinue()
                .GoToAboutYourApprenticeshipPage()
                .EnterMoreDetailsAndContinue()
                .GoToContactDetailsPage()
                .EnterContactDetailsAndContinue()
                .SubmitApplication()
                .ContinueToMyAccount();

            return NavigateToTransferMatchingPage().ViewApplicationsIhaveSubmitted().OpenPledgeApplication("AWAITING APPROVAL").SetPledgeApplication();
        }

        private ApprenticeshipTrainingPage ApplyForAnInvalidPledge(EasAccountUser user)
        {
            GoToTransferMatchingAndSignIn(user);

            return GoToApprenticeshipTrainingPage(new CreateATransfersApplicationPage(_context));
        }

        private ApplicationSubmittedPage ApplyForAPledge(EasAccountUser user)
        {
            GoToTransferMatchingAndSignIn(user);

            return SubmitApplication(new CreateATransfersApplicationPage(_context));
        }

        private void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);

        private void GoToTransferMatchingAndSignIn(EasAccountUser user)
        {
            GoToTransferMacthingApplyUrl();

            UpdateOrganisationName(_sender);

            var page = new TransferFundDetailsPage(_context, _isAnonymousPledge);

            _receiver = user.OrganisationName;

            UpdateOrganisationName(_receiver);

            page.ApplyForTransferFunds().EnterLoginDetailsAndClickSignIn(user.Username, user.Password);
        }

        private SignInPage ApplyForTransferFunds()
        {
            GoToTransferMacthingApplyUrl();

            return new TransferFundDetailsPage(_context).ApplyForTransferFunds();
        }

        private void AssertErrorMessage(TransferMatchingBasePage page, string expectedErrorMessage)
        {
            string actualErrorMessage = page.GetErrorMessage();

            Assert.Multiple(() =>
            {
                StringAssert.Contains("There is a problem", actualErrorMessage);

                StringAssert.Contains(expectedErrorMessage, actualErrorMessage);
            });
        }

        private void CreateATransferPledge(EasAccountUser login)
        {
            LoginAsSender(login);

            CreateATransferPledge(true).ContinueToPledgeVerificationPage().SetPledgeDetail();
        }

        private void LoginAsReceiver(EasAccountUser login, bool isLevy)
        {
            _receiver = login.OrganisationName;

            _loginFromCreateAcccountPageHelper.Login(login, true);
        }

        private void LoginAsSender(EasAccountUser login)
        {
            _sender = login.OrganisationName;

            _loginFromCreateAcccountPageHelper.Login(login, true);
        }

        private void LoginAsSender(MultipleEasAccountUser login)
        {
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(_context, login)
            {
                OrganisationName = login.OrganisationName
            };

            _multipleAccountsLoginHelper.Login(login, true);

            _sender = login.OrganisationName;

            _receiver = login.SecondOrganisationName;
        }
    }
}
