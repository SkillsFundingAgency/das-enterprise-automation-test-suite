using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.TransferMatching.APITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using MyAccountTransferFundingPage = SFA.DAS.TransferMatching.UITests.Project.Tests.Pages.MyAccountTransferFundingPage;

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
        private readonly TransferMatchingSqlDataHelper _transferMatchingSqlDataHelper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private readonly AccountSignOutHelper _accountSignOutHelper;
        private string _sender;
        private string _receiver;
        private bool _isAnonymousPledge;
        private bool _isImmediateAutoApprovalPledge;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly EmployerHomePageStepsHelper _employerHomePageStepsHelper;
        private readonly TransferMatchingJobsHelper _transferMatchingJobsHelper;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _isAnonymousPledge = false;
            _isImmediateAutoApprovalPledge = false;
            _loginFromCreateAcccountPageHelper = new CreateAccountEmployerPortalLoginHelper(context);
            _transferMatchingStepsHelper = new SubmitApplicationHelper();
            _objectContext = context.Get<ObjectContext>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _employerHomePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _transferMatchingSqlDataHelper = new TransferMatchingSqlDataHelper(_objectContext, context.Get<DbConfig>());
            _transferMatchingJobsHelper = new TransferMatchingJobsHelper(context);
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
            SignOut();

            LoginAsSender(_context.GetUser<TransferMatchingUser>());

            NavigateToTransferMatchingPage().GoToAccountHomePage().ClickTask();
        }

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

        [Then(@"the non levy employer can apply for the pledge but is not immediately autoapproved")]
        public void WhenTheNonLevyEmployerAppliesForThePledgeButNotImmediatelyAutoApproved()
        {
            _receiver = GoToTransferMatchingAndSignIn(_context.GetUser<NonLevyUser>(), _sender, _isAnonymousPledge);
            _transferMatchingStepsHelper.SubmitApplication(new CreateATransfersApplicationPage(_context));
            OpenPledgeApplication("AWAITING APPROVAL").SetPledgeApplication();
        }

        [Then(@"the non levy employer cannot exceed the available pledge funding")]
        public void ThenTheNonLevyEmployerCannotExceedTheAvailablePledgeFunding()
            => AssertErrorMessage(ApplyForAnInvalidPledge(_context.GetUser<NonLevyUser>()).EnterAmountMoreThanAvailableFunding(), "Cost of training exceeds the amount remaining in this pledge");

        [Then(@"the levy employer can download excel file")]
        public void ThenTheLevyEmployerCanDownloadExcelFilen() => GoToTransferPledgePageAsReceiver().DownloadExcel();

        [Then(@"the levy employer can close the pledge")]
        public void ThenTheLevyEmployerCanCloseThePledge() => ClosePledge().ConfirmClose().ConfirmCloseStatus();

        [Then(@"the levy employer doesn't close the pledge")]
        public void ThenTheLevyEmployerDoesntCloseThePledge() => ClosePledge().DontClose();

        [Then(@"the levy employer can approve the application")]
        public void ThenTheLevyEmployerCanApproveTheApplication() => GoToApprovingTheApprenticeshipDetailsPage().ManuallyApproveApplication();

        [Then(@"the levy employer can approve the application and verify costing model")]
        public void ThenTheLevyEmployerCanApproveTheApplicationAndVerifyCostingModel() => GoToApprovingTheApprenticeshipDetailsPage().ManuallyApproveApplication().ClickBackButton().VerifyCostingModel();

        [Then(@"the levy employer can auto approve the application")]
        public void ThenTheLevyEmployerCanAutoApproveTheApplication() => GoToApprovingTheApprenticeshipDetailsPage().AutoApproveApplication();

        [Then(@"the levy employer can reject the application")]
        public void ThenTheLevyEmployerCanRejectTheApplication() => GoToApproveAppliationPage().RejectApplication();

        [Then(@"the levy employer can view the approved application")]
        public void ThenTheLevyEmployerCanViewApprovedApplication() => GoToTransferPledgePageAsReceiver().ConfirmApplicationStatus("AWAITING ACCEPTANCE BY APPLICANT");

        [Then(@"the levy employer can view the awaiting your approval application")]
        public void ThenTheLevyEmployerCanViewAwaitingYourApprovalApplication() => GoToTransferPledgePageAsReceiver().ConfirmApplicationStatus("AWAITING YOUR APPROVAL");

        [Then(@"the non levy employer can accept funding")]
        public void ThenTheNonLevyEmployerCanAcceptFunding() => OpenApprovedPledgeApplication().VerifyAgreeToTermsIsMandatoryAndAcceptFunding().ViewMyApplications().OpenPledgeApplication("FUNDS AVAILABLE");

        [Then(@"the non levy employer can withdraw funding")]
        public void ThenTheNonLevyEmployerCanWithdrawFunding() { OpenApprovedPledgeApplication().WithdrawFunding().ReturnToMyAccount(); OpenPledgeApplication("WITHDRAWN"); }

        [Then(@"the non levy employer can open approved pledge application")]
        public void ThenTheNonLevyEmployerCanOpenApprovedPledgeApplication()
        {
            _employerHomePageStepsHelper.GotoEmployerHomePage();
            OpenPledgeApplication("APPROVED, AWAITING YOUR ACCEPTANCE");
        }

        [Then(@"the non levy employer can open awaiting approval pledge application")]
        public void ThenTheNonLevyEmployerCanOpenAwaitingApprovalPledgeApplication()
        {
            _employerHomePageStepsHelper.GotoEmployerHomePage();
            OpenPledgeApplication("AWAITING APPROVAL");
        }

        [Then(@"the non levy employer can withdraw funding before approval")]
        public void ThenTheNonLevyEmployerCanWithdrawFundingBeforeApproval()
        {
            UpdateOrganisationName(_receiver);

            SignOut();

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
        public void TheLevyEmployerCannotExceedTheMaximumFundingAvailable() => AssertErrorMessage(GoToEnterPlegeAmountPage().EnterInValidAmount(), "You need to enter an amount greater than");

        [Then(@"the viewer cannot create pledge")]
        public void TheViewerCannotCreatePledge()
        { NavigateToTransferMatchingPage().CanCreateTransferPledge(); }


        [Given(@"the levy employer can create pledge using default criteria")]
        [Then(@"the levy employer can create pledge using default criteria")]
        public void TheLevyEmployerCanCreatePledgeUsingDefaultCriteria()
        {
            var page = CreateATransferPledge(true, _isImmediateAutoApprovalPledge, false);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(CreateATransferPledgePage.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(CreateATransferPledgePage.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(CreateATransferPledgePage.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(CreateATransferPledgePage.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }

        [Given(@"the levy employer can create pledge for immediate approval using default criteria")]
        [Then(@"the levy employer can create pledge for immediate approval using default criteria")]
        public void TheLevyEmployerCanCreatePledgeForImmediateApprovalUsingDefaultCriteria()
        {
            _isImmediateAutoApprovalPledge = true;

            var page = CreateATransferPledge(true, _isImmediateAutoApprovalPledge, false);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(CreateATransferPledgePage.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(CreateATransferPledgePage.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(CreateATransferPledgePage.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(CreateATransferPledgePage.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }


        [Given(@"the levy employer can create pledge using non default criteria and immediate approval")]
        [Then(@"the levy employer can create pledge using non default criteria and immediate approval")]
        public void TheLevyEmployerCanCreatePledgeUsingNonDefaultCriteriaWithImmediateApproval()
        {
            _isImmediateAutoApprovalPledge = true;
            _isAnonymousPledge = true;

            _pledgeVerificationPage = CreateATransferPledge(false, _isImmediateAutoApprovalPledge, false)
                .GoToAddtheLocationPage().EnterLocation()
                .GoToChoosetheSectorPage().SelectSetorAndContinue()
                .GoToChooseTheTypesOfJobPage().SelectTypeOfJobAndContinue()
                .GoToChooseTheLevelPage().SelectLevelAndContinue()
                .ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }

        [Given(@"the levy employer can create pledge using minimal funding")]
        [Then(@"the levy employer can create pledge using minimal funding")]
        public void TheLevyEmployerCanCreatePledgeUsingMinimalFunding()
        {
            var page = CreateATransferPledge(true, _isImmediateAutoApprovalPledge, true);

            StringAssert.AreEqualIgnoringCase("All of England", page.GetCriteriaValue(CreateATransferPledgePage.LocationLink));
            StringAssert.AreEqualIgnoringCase("All sectors and industries", page.GetCriteriaValue(CreateATransferPledgePage.SectorLink));
            StringAssert.AreEqualIgnoringCase("All apprenticeship job roles", page.GetCriteriaValue(CreateATransferPledgePage.TypeOfJobRoleLink));
            StringAssert.AreEqualIgnoringCase("All qualification levels", page.GetCriteriaValue(CreateATransferPledgePage.LevelLink));

            _pledgeVerificationPage = page.ContinueToPledgeVerificationPage();

            SetPledgeDetail();
        }

        [Then(@"the levy employer can create anonymous pledge using non default criteria")]
        public void TheLevyEmployerCanCreateAnonymousPledgeUsingNonDefaultCriteria()
        {
            _isAnonymousPledge = true;

            _pledgeVerificationPage = CreateATransferPledge(false, _isImmediateAutoApprovalPledge, false)
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
                .SubmitValidApprenticeDetails(false)
                .EmployerFirstApproveAndNotifyTrainingProvider();

            var cohortReference = apprenticeDetailsApprovedPage.CohortReferenceFromUrl();
            _objectContext.SetCohortReference(cohortReference);
            _objectContext.SetNoOfApprentices(1);
        }

        [Then(@"wait for 6 weeks")]
        public void ApplicationIsApprovedAfter6Weeks()
        {
            //update created on date to 6 weeks later
            _transferMatchingSqlDataHelper.UpdateCreatedDateForApplicationToToday(_objectContext.GetPledgeDetail().PledgeId);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            // trigger autoapproval job
            _transferMatchingJobsHelper.RunApplicationsWithAutomaticApprovalJob();
        }

        public string GoToTransferMatchingAndSignIn(EasAccountUser receiver, string _sender, bool _isAnonymousPledge)
        {
            SignOutAndGoToTransferMacthingApplyUrl();

            UpdateOrganisationName(_sender);

            var page = new TransferFundDetailsPage(_context, _isAnonymousPledge);

            var _receiver = receiver.OrganisationName;

            UpdateOrganisationName(_receiver);

            page.ApplyForTransferFunds().Login(receiver.Username, receiver.IdOrUserRef).Continue();

            return _receiver;
        }


        [Then(@"the levy employer can filter pledges")]
        public void ThenTheLevyEmployerCanFilterPledges()
        {
            NavigateToTransferMatchingPage().GoToFindABusinessPage().GoToOpportunitiesPage().SelectAndApplyFilters();
        }

        public void SignOutAndGoToTransferMacthingApplyUrl()
        {
            SignOut();

            _tabHelper.OpenInNewTab(UrlConfig.TransferMacthingApplyUrl(_objectContext.GetPledgeDetail().PledgeId));
        }

        public void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);

        public void SignOut() => _accountSignOutHelper.SignOut();

        private ApplicationsDetailsPage OpenApprovedPledgeApplication()
        {
            UpdateOrganisationName(_sender);

            SignOut();

            LoginAsReceiver(_context.Get<NonLevyUser>());

            return OpenPledgeApplication("APPROVED, AWAITING YOUR ACCEPTANCE");
        }

        private void CanApplyForTransferOppurtunity(bool canApply)
        {
            Assert.That(NavigateToTransferMatchingPage().CanApplyForTransferOppurtunity(), Is.EqualTo(canApply), canApply ? "User can't apply for transfer oppurtunity" : "User can apply for transfer oppurtunity");
        }

        private void CreateTransferPledge(bool navigate, bool canCreateTransferPledge)
        {
            if (navigate) new HomePage(_context, true).GoToYourAccountsPage().ClickAccountLink(_receiver);

            Assert.That(NavigateToTransferMatchingPage().CanCreateTransferPledge(), Is.EqualTo(canCreateTransferPledge), canCreateTransferPledge ? "User can't create transfer pledge" : "User can create transfer pledge");
        }

        private ApprovingTheApprenticeshipDetailsPage GoToApprovingTheApprenticeshipDetailsPage() => GoToApproveAppliationPage().GoToApprovingTheApprenticeshipDetailsPage();

        private TransferPledgePage VerifyPlegdeAmount() => GoToTransferPledgePageAsSender().VerifyPledgeAmount();
        private ClosePledgePage ClosePledge() => GoToTransferPledgePageAsSender().ClosePledge();

        private TransferPledgePage BulkReject() => GoToTransferPledgePageAsSender().SelectBulkReject().CancelBulkReject().SelectBulkReject().BulkReject();

        private TransferPledgePage SortApplications() => GoToTransferPledgePageAsSender().SortByApplicant();

        private TransferPledgePage GoToTransferPledgePageAsSender()
        {
            SignOut();

            LoginAsSender(_context.GetUser<TransferMatchingUser>());

            return NavigateToTransferMatchingPage().GoToViewMyTransferPledgePage().GoToTransferPledgePage();
        }

        private ApproveAppliationPage GoToApproveAppliationPage() => GoToTransferPledgePageAsReceiver().GoToApproveAppliationPage();

        private TransferPledgePage GoToTransferPledgePageAsReceiver()
        {
            SignOut();

            UpdateOrganisationName(_sender);

            _multipleAccountsLoginHelper.ReLogin();

            NavigateToTransferMatchingPage();

            UpdateOrganisationName(_receiver);

            return GoToViewMyTransferPledgePage().GoToTransferPledgePage();
        }

        protected void SetPledgeDetail() => _pledgeVerificationPage.SetPledgeDetail();

        private CreateATransferPledgePage CreateATransferPledge(bool showOrgName, bool immediateMatch, bool useMinimalFunding) =>
            GoToEnterPlegeAmountPage().EnterInValidAmountForCreateAPledge(useMinimalFunding)
            .GoToPledgeOrganisationNamePageOptionPage().EnterValidOrgNameChoice(showOrgName)
            .GoToPledge100PercentMatchPage().EnterValidMatchChoice(immediateMatch);

        private PledgeAmountPage GoToEnterPlegeAmountPage() =>
            NavigateToTransferMatchingPage()
            .GotoCreateTransfersPledgePage()
            .StartCreatePledge()
            .GoToPledgeAmountPage()
            .CaptureAvailablePledgeAmount();

        private ManageTransferMatchingPage NavigateToTransferMatchingPage() => _manageTransferMatchingPage = new HomePageFinancesSection_YourTransfers(_context).NavigateToTransferMatchingPage();

        private MyTransferPledgesPage GoToViewMyTransferPledgePage() => _manageTransferMatchingPage.GoToViewMyTransferPledgePage();

        private ApplicationsDetailsPage SubmitApplication(CreateATransfersApplicationPage page)
        {
            _transferMatchingStepsHelper.SubmitApplication(page, _isImmediateAutoApprovalPledge ? "" : _objectContext.GetPledgeDetail().PledgeId);

            return OpenPledgeApplication(_isImmediateAutoApprovalPledge ? "APPROVED, AWAITING YOUR ACCEPTANCE" : "AWAITING APPROVAL").SetPledgeApplication();
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

        private StubSignInEmployerPage ApplyForTransferFunds()
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

            CreateATransferPledge(true, _isImmediateAutoApprovalPledge, false).ContinueToPledgeVerificationPage().SetPledgeDetail();
        }

        private void LoginAsReceiver(EasAccountUser login)
        {
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