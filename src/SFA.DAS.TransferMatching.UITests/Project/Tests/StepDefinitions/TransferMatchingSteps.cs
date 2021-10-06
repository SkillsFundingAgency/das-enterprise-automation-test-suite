using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using MyAccountTransferFundingPage = SFA.DAS.TransferMatching.UITests.Project.Tests.Pages.MyAccountTransferFundingPage;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;

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
        private readonly TransferMatchingUser _transferMatchingUser;
        private readonly TMDataHelper _tMDataHelper;
        private string _sender;
        private string _receiver;
        private bool _isAnonymousPledge;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _objectContext = context.Get<ObjectContext>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
            _transferMatchingUser = context.GetUser<TransferMatchingUser>();
            _tMDataHelper = context.Get<TMDataHelper>();
            _sender = _transferMatchingUser.OrganisationName;
            _receiver = _transferMatchingUser.SecondOrganisationName;
            _isAnonymousPledge = false;
            _loginFromCreateAcccountPageHelper = new EmployerLoginFromCreateAcccountPageHelper(_context);
        }

        [Given(@"the levy employer login using existing transactor user account")]
        public void GivenTheEmployerLoginsUsingExistingTransactorUserAccount()
        {
            var user = _context.GetUser<TransactorUser>();

            _sender = user.OrganisationName;

            _loginFromCreateAcccountPageHelper.Login(user, true);
        }

        [Then(@"the non levy employer cannot create pledge")]
        public void ThenTheNonLevyEmployerCannotCreatePledge() { _tMDataHelper.NoOfApprentice = 0; EnterPlegeAmount(false); }

        [When(@"the receiver levy employer applies for the pledge")]
        public void WhenTheReceiverLevyEmployerAppliesForThePledge() => ApplyForAPledge(_context.GetUser<LevyUser>());

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
        public void TheLevyEmployerLoginsUsingExistingTransferMatchingAccount()
        {
            var user = _context.GetUser<TransferMatchingUser>();

            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(_context, user)
            {
                OrganisationName = user.OrganisationName
            };

            _multipleAccountsLoginHelper.Login(user, true);
        }
        [Then(@"the levy employer cannot exceed the maximum funding available")]
        public void TheLevyEmployerCannotExceedTheMaximumFundingAvailable() => EnterPlegeAmount(true);

        [Then(@"the levy employer can create pledge using default criteria")]
        public void TheLevyEmployerCanCreatePledgeUsingDefaultCriteria()
        {
            var page = CreateATransferPledge(true);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(page.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(page.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(page.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(page.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeId();
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

            SetPledgeId();
        }

        [Then(@"the levy employer can view pledges from verification page")]
        public void TheLevyEmployerCanViewPledgesFromVerificationPage() => _pledgeVerificationPage.ViewYourPledges().VerifyPledge();

        [Then(@"the user can view transfer pledge")]
        public void TheEmployerCanViewTransfers() => GoToViewMyTransferPledgePage();

        [Then(@"the user can not create transfer pledge")]
        public void ThenTheUserCanNotCreateTransferPledge() => Assert.AreEqual(false, NavigateToTransferMatchingPage().CanCreateTransferPledge(), "View user can create transfer pledge");

        protected void SetPledgeId() => _pledgeVerificationPage.SetPledgeId();

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
            _accountSignOutHelper.SignOut();

            _tabHelper.OpenInNewTab(UrlConfig.TransferMacthingApplyUrl(_objectContext.GetPledgeId()));
        }

        private ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage(CreateATransfersApplicationPage page) => page.GoToApprenticeshipTrainingPage();

        private ApplicationSubmittedPage SubmitApplication(CreateATransfersApplicationPage page)
        {
            return GoToApprenticeshipTrainingPage(page)
                .EnterAppTrainingDetailsAndContinue()
                .GoToYourBusinessDetailsPage()
                .EnterBusinessDetailsAndContinue()
                .GoToAboutYourApprenticeshipPage()
                .EnterMoreDetailsAndContinue()
                .GoToContactDetailsPage()
                .EnterContactDetailsAndContinue()
                .SubmitApplication();
        }

        private ApprenticeshipTrainingPage ApplyForAnInvalidPledge(LoginUser user)
        {
            GoToTransferMatchingAndSignIn(user);

            return GoToApprenticeshipTrainingPage(new CreateATransfersApplicationPage(_context));
        }

        private ApplicationSubmittedPage ApplyForAPledge(LoginUser user)
        {
            GoToTransferMatchingAndSignIn(user);

            return SubmitApplication(new CreateATransfersApplicationPage(_context));
        }

        private void GoToTransferMatchingAndSignIn(LoginUser user)
        {
            GoToTransferMacthingApplyUrl();

            _objectContext.UpdateOrganisationName(_sender);

            var page = new TransferFundDetailsPage(_context, _isAnonymousPledge);

            _receiver = user.OrganisationName;

            _objectContext.UpdateOrganisationName(_receiver);

            page.ApplyForTransferFunds().EnterLoginDetailsAndClickSignIn(user.Username, user.Password);
        }

        private SignInPage ApplyForTransferFunds()
        {
            GoToTransferMacthingApplyUrl();

            return new TransferFundDetailsPage(_context).ApplyForTransferFunds();
        }

        private void EnterPlegeAmount(bool exceedMaxFunding) => AssertErrorMessage(GoToEnterPlegeAmountPage().EnterInValidAmount(exceedMaxFunding), "Enter a number between");

        private void AssertErrorMessage(TransferMatchingBasePage page, string expectedErrorMessage)
        {
            string actualErrorMessage = page.GetErrorMessage();

            Assert.Multiple(() =>
            {
                StringAssert.Contains("There is a problem", actualErrorMessage);

                StringAssert.Contains(expectedErrorMessage, actualErrorMessage);
            });

        }
    }
}
