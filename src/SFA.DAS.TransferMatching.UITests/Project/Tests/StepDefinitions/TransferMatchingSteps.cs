using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project;
using Polly;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransferMatchingSteps
    {
        private readonly ScenarioContext _context;
        private PledgeVerificationPage _pledgeVerificationPage;
        private ManageTransferMatchingPage _manageTransferMatchingPage;
        private MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly CreateAccountEmployerPortalLoginHelper _loginFromCreateAcccountPageHelper;
        private readonly SubmitApplicationHelper _transferMatchingStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly AccountSignOutHelper _accountSignOutHelper;
        private string _sender;
        private string _receiver;
        private bool _isAnonymousPledge;
        private readonly RestartWebDriverHelper _helper;
        private readonly string _tranferBaseUrl;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;


        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _isAnonymousPledge = false;
            _loginFromCreateAcccountPageHelper = new CreateAccountEmployerPortalLoginHelper(context);
            _transferMatchingStepsHelper = new SubmitApplicationHelper();
            _objectContext = context.Get<ObjectContext>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
            _helper = new RestartWebDriverHelper(context);
            _tranferBaseUrl = UrlConfig.EmployerApprenticeshipService_BaseUrl;
            _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
        }

        [Given(@"the levy employer who are currently sending transfer funds login")]
        public void GivenTheLevyEmployerWhoAreCurrentlySendingTransferFundsLogin() => LoginAsSender(_context.GetUser<TransfersUser>());

        [Given(@"the levy employer who are not currently sending transfer funds login")]
        public void GivenTheLevyEmployerWhoAreNotCurrentlySendingTransferFundsLogin() => LoginAsSender(_context.GetUser<TransfersUserNoFunds>());

        [Then(@"the levy employer can apply for transfer opportunities")]
        public void ThenTheLevyEmployerCanApplyForTransferOpportunities() => NavigateToTransferMatchingPage().GoToFindABusinessPage();

        [Then(@"the levy employer can view the task")]
        public void ThenTheLevyEmployerCanViewTheTask()
        {
            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

            LoginAsSender(_context.GetUser<TransferMatchingUser>());

            NavigateToTransferMatchingPage().GoToAccountHomePage().ClickTask();
        }

        [Given(@"the another levy employer creates a pledge")]
        public void GivenTheAnotherLevyEmployerCreatesAPledge()
        {
            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

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

        [Then(@"the levy employer can download excel file")]
        public void ThenTheLevyEmployerCanDownloadExcelFilen() => GoToTransferPledgePageAsReceiver().DownloadExcel();

        [Then(@"the levy employer can close the pledge")]
        public void ThenTheLevyEmployerCanCloseThePledge() => ClosePledge().ConfirmClose().ConfirmCloseStatus();

        [Then(@"the levy employer doesn't close the pledge")]
        public void ThenTheLevyEmployerDoesntCloseThePledge() => ClosePledge().DontClose();

        [Then(@"the levy employer can approve the application")]
        public void ThenTheLevyEmployerCanApproveTheApplication() => GoToApprovingTheApprenticeshipDetailsPage().ManuallyApproveApplication();

        [Then(@"the levy employer can auto approve the application")]
        public void ThenTheLevyEmployerCanAutoApproveTheApplication() => GoToApprovingTheApprenticeshipDetailsPage().AutoApproveApplication();

        [Then(@"the levy employer can reject the application")]
        public void ThenTheLevyEmployerCanRejectTheApplication() => GoToApproveAppliationPage().RejectApplication();

        [Then(@"the non levy employer can accept funding")]
        public void ThenTheNonLevyEmployerCanAcceptFunding() => OpenApprovedPledgeApplication().VerifyAgreeToTermsIsMandatoryAndAcceptFunding().ViewMyApplications().OpenPledgeApplication("FUNDS AVAILABLE");

        [Then(@"the non levy employer can withdraw funding")]
        public void ThenTheNonLevyEmployerCanWithdrawFunding() { OpenApprovedPledgeApplication().WithdrawFunding().ReturnToMyAccount(); OpenPledgeApplication("WITHDRAWN"); }

        [Then(@"the non levy employer can withdraw funding before approval")]
        public void ThenTheNonLevyEmployerCanWithdrawFundingBeforeApproval()
        {
            UpdateOrganisationName(_receiver);

            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

            LoginAsReceiver(_context.Get<NonLevyUser>());

            OpenPledgeApplication("AWAITING APPROVAL").WithdrawBeforeApproval().ReturnToMyAccount(); OpenPledgeApplication("WITHDRAWN");

        }

        [Then(@"the pledge is available to apply")]
        public void ThenThePledgeIsAvailableToApply() => ApplyForTransferFunds();

        [When(@"the transfer receiver applies for the pledge")]
        public void TheTransferReceiverAppliesForThePledge()
        {
            var signInPage = ApplyForTransferFunds();

            UpdateOrganisationName(_receiver);

            _multipleAccountsLoginHelper.LoginToMyAccountTransferFunding(signInPage);

            SubmitApplication(new MyAccountTransferFundingPage(_context).GoToCreateATransfersApplicationPage(_receiver));
        }

        [Given(@"the levy employer logins using existing transfer matching account")]
        public void TheLevyEmployerLoginsUsingExistingTransferMatchingAccount() => LoginAsSender(_context.GetUser<TransferMatchingUser>());

        [Then(@"the levy employer cannot exceed the maximum funding available")]
        public void TheLevyEmployerCannotExceedTheMaximumFundingAvailable() => AssertErrorMessage(GoToEnterPlegeAmountPage().EnterInValidAmount(), "Enter a number between");

        [Then(@"the viewer cannot create pledge")]
        public void TheViewerCannotCreatePledge()
        { NavigateToTransferMatchingPage().CanCreateTransferPledge(); }


        [Given(@"the levy employer can create pledge using default criteria")]
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

        [Then(@"the levy employer can sort the pledges")]
        public void TheLevyEmployerCanSortThePledges() => SortApplications();

        [When(@"the levy employer is viewing pledges from verification page")]
        [Then(@"the levy employer can view pledges from verification page")]
        public void TheLevyEmployerCanViewPledgesFromVerificationPage() => _pledgeVerificationPage.ViewYourPledges().ConfirmActiveStatus().VerifyPledge();

        [Then(@"the user can view transfer pledge")]
        public void TheEmployerCanViewTransfers() => GoToViewMyTransferPledgePage();

        [Then(@"the levy employer currently receiving funds can not create pledge")]
        public void ThenTheLevyEmployerCurrentlyReceivingFundsCanNotCreatePledge() => CreateTransferPledge(true, false);

        [Then(@"the levy employer currently receiving funds can create pledge")]
        public void ThenTheLevyEmployerCurrentlyReceivingFundsCanCreatePledge() => CreateTransferPledge(true, true);

        [Then(@"the user can not create transfer pledge")]
        public void TheUserCanNotCreateTransferPledge() => CreateTransferPledge(false, false);

        [Then(@"the user can create transfer pledge")]
        public void TheUserCanCreateTransferPledge() => CreateTransferPledge(false, true);

        [Then(@"the levy employer can not apply for transfer opportunities")]
        public void ThenTheLevyEmployerCanNotApplyForTransferOpportunities() => CanApplyForTransferOppurtunity(false);

        [Then(@"the levy employer is able to apply for transfer opportunities")]
        public void ThenTheLevyEmployerIsAbletoApplyForTransferOpportunities() => CanApplyForTransferOppurtunity(true);

        [Then(@"the levy employer can bulk reject application")]
        public void ThenTheLevyEmployerCanBulkRejectApplication() => BulkReject();

        [Then(@"Then the levy employer can view transfer allowance")]
        public void ThenTheLevyEmployerCanViewTransferAllowance() => NavigateToTransferMatchingPage().VerifyTransferAllowanceText();

        [Then(@"the levy employer can view pleged amount")]
        public void ThenTheLevyEmployerCanViewPLedgedAmount() => VerifyPlegdeAmount();

        [Then(@"the non levy employer can add apprentice to the pledgeApplication")]
        public void ThenTheNonLevyEmployerCanAddApprenticeToThePledgeApplication()
        {
            var apprenticeDetailsApprovedPage = new UseTransferFundsPage(_context).ClickOnStartNowButton()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices()
                .EmployerSelectsAStandard()
                .SubmitValidPersonalDetails()
                .SubmitValidTrainingDetails(false)
                .EmployerFirstApproveAndNotifyTrainingProvider();

            var cohortReference = apprenticeDetailsApprovedPage.CohortReferenceFromUrl();
            _objectContext.SetCohortReference(cohortReference);
            _objectContext.SetNoOfApprentices(1);
        }

        public string GoToTransferMatchingAndSignIn(EasAccountUser receiver, string _sender, bool _isAnonymousPledge)
        {
            SignOutAndGoToTransferMacthingApplyUrl();

            UpdateOrganisationName(_sender);

            var page = new TransferFundDetailsPage(_context, _isAnonymousPledge);

            var _receiver = receiver.OrganisationName;

            UpdateOrganisationName(_receiver);

            page.ApplyForTransferFunds().EnterLoginDetailsAndClickSignIn(receiver.Username, receiver.Password);

            return _receiver;
        }


        [Then(@"the levy employer can filter pledges")]
        public void ThenTheLevyEmployerCanFilterPledges()
        {
            NavigateToTransferMatchingPage().GoToFindABusinessPage().GoToOpportunitiesPage().SelectAndApplyFilters();
        }

        public void SignOutAndGoToTransferMacthingApplyUrl()
        {
            _helper.RestartWebDriver(UrlConfig.TransferMacthingApplyUrl(_objectContext.GetPledgeDetail().PledgeId), "TransferMatching");
        }

        public void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);

        public void SignOut() => _accountSignOutHelper.SignOut();

        private ApplicationsDetailsPage OpenApprovedPledgeApplication()
        {
            UpdateOrganisationName(_sender);

            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

            LoginAsReceiver(_context.Get<NonLevyUser>());

            return OpenPledgeApplication("APPROVED, AWAITING YOUR ACCEPTANCE");
        }

        private void CanApplyForTransferOppurtunity(bool canApply) => Assert.AreEqual(canApply, NavigateToTransferMatchingPage().CanApplyForTransferOppurtunity(), canApply ? "User can't apply for transfer oppurtunity" : "User can apply for transfer oppurtunity");

        private void CreateTransferPledge(bool navigate, bool canCreateTransferPledge)
        {
            if (navigate) new HomePage(_context, true).GoToYourAccountsPage().ClickAccountLink(_receiver);

            Assert.AreEqual(canCreateTransferPledge, NavigateToTransferMatchingPage().CanCreateTransferPledge(), canCreateTransferPledge ? "User can't create transfer pledge" : "User can create transfer pledge");
        }

        private ApprovingTheApprenticeshipDetailsPage GoToApprovingTheApprenticeshipDetailsPage() => GoToApproveAppliationPage().GoToApprovingTheApprenticeshipDetailsPage();

        private TransferPledgePage VerifyPlegdeAmount() => GoToTransferPledgePageAsSender().VerifyPledgeAmount();
        private ClosePledgePage ClosePledge() => GoToTransferPledgePageAsSender().ClosePledge();

        private TransferPledgePage BulkReject() => GoToTransferPledgePageAsSender().SelectBulkReject().CancelBulkReject().SelectBulkReject().BulkReject();

        private TransferPledgePage SortApplications() => GoToTransferPledgePageAsSender().SortByApplicant();

        private TransferPledgePage GoToTransferPledgePageAsSender()
        {
            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

            LoginAsSender(_context.GetUser<TransferMatchingUser>());

            return NavigateToTransferMatchingPage().GoToViewMyTransferPledgePage().GoToTransferPledgePage();
        }

        private ApproveAppliationPage GoToApproveAppliationPage() => GoToTransferPledgePageAsReceiver().GoToApproveAppliationPage();

        private TransferPledgePage GoToTransferPledgePageAsReceiver()
        {
            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");

            UpdateOrganisationName(_sender);

            _multipleAccountsLoginHelper.ReLogin();

            NavigateToTransferMatchingPage();

            UpdateOrganisationName(_receiver);

            return GoToViewMyTransferPledgePage().GoToTransferPledgePage();
        }

        protected void SetPledgeDetail() => _pledgeVerificationPage.SetPledgeDetail();

        private CreateATransferPledgePage CreateATransferPledge(bool showOrgName) => GoToEnterPlegeAmountPage().EnterValidAmountAndOrgName(showOrgName);

        private PledgeAmountAndOptionToHideOrganisastionNamePage GoToEnterPlegeAmountPage() =>
            NavigateToTransferMatchingPage()
            .GotoCreateTransfersPledgePage()
            .StartCreatePledge()
            .GoToPledgeAmountAndOptionPage()
            .CaptureAvailablePledgeAmount();

        private ManageTransferMatchingPage NavigateToTransferMatchingPage() => _manageTransferMatchingPage = new HomePageFinancesSection_YourTransfers(_context).NavigateToTransferMatchingPage();

        private MyTransferPledgesPage GoToViewMyTransferPledgePage() => _manageTransferMatchingPage.GoToViewMyTransferPledgePage();

        private ApplicationsDetailsPage SubmitApplication(CreateATransfersApplicationPage page)
        {
            _transferMatchingStepsHelper.SubmitApplication(page);

            return OpenPledgeApplication("AWAITING APPROVAL").SetPledgeApplication();
        }

        private ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus) => NavigateToTransferMatchingPage().ViewApplicationsIhaveSubmitted().OpenPledgeApplication(expectedStatus);

        private ApprenticeshipTrainingPage ApplyForAnInvalidPledge(EasAccountUser user)
        {
            _receiver = GoToTransferMatchingAndSignIn(user, _sender, _isAnonymousPledge);

            return _transferMatchingStepsHelper.GoToApprenticeshipTrainingPage(new CreateATransfersApplicationPage(_context));
        }

        private ApplicationsDetailsPage ApplyForAPledge(EasAccountUser user)
        {
            _receiver = GoToTransferMatchingAndSignIn(user, _sender, _isAnonymousPledge);

            return SubmitApplication(new CreateATransfersApplicationPage(_context));
        }

        private SignInPage ApplyForTransferFunds()
        {
            SignOutAndGoToTransferMacthingApplyUrl();

            return new TransferFundDetailsPage(_context, false).ApplyForTransferFunds();
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

        private void LoginAsReceiver(EasAccountUser login)
        {
            _helper.RestartWebDriver(_tranferBaseUrl, "TransferMatching");
            _receiver = login.OrganisationName;

            _loginFromCreateAcccountPageHelper.Login(login, false);
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

        [Then(@"Verify a new live apprenticeship record is created")]
        public void ThenVerifyANewLiveApprenticeshipRecordIsCreated()
        {
            UpdateOrganisationName(_receiver);

            var manageYourApprenticePage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }
    }
}