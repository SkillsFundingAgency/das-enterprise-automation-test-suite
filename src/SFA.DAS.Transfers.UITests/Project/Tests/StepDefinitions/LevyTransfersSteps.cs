using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{


    [Binding]
    public class LevyTransfersSteps
    {
        public static string newPledgeID;
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransfersEmployerStepsHelper _employerStepsHelper;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly TransfersUser _transfersUser;
        private readonly LevyUser _levyUser;
        private HomePage _homePage;
        

        private readonly string _sender;
        private readonly string _receiver;

        public LevyTransfersSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransfersUser>();
            _levyUser = context.GetUser<LevyUser>();
            _sender = _transfersUser.OrganisationName;
            _receiver = _transfersUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new TransfersEmployerStepsHelper(context);
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
            

        }

        [Given(@"I am logged in as a Levy Payer")]

        public void GivenIAmLoggedInAsALevyPayer() =>  _employerPortalLoginHelper.Login(_levyUser, true);

        [Given(@"I am on the Manage Apprenticeships Page")]
        public void GivenIAmOnTheManageApprenticeshipsPage()
        {
            ManageApprenticeshipsPage manageApprenticeshipsPage = new ManageApprenticeshipsPage(_context);
        
            bool Test1 =  manageApprenticeshipsPage.CheckPageTitle();
        }

        [When(@"I click on view my transfers")]
        public void WhenIClickOnViewMyTransfers()
        {
            ManageApprenticeshipsPage manageApprenticeshipsPage = new ManageApprenticeshipsPage(_context);

            manageApprenticeshipsPage.ClickViewMyTransfers();
        }

        [Then(@"I am on the View Transfers Page")]
        public void ThenIAmOnTheViewTransfersPage()
        {
            YourTransfersPage yourTransfersPage = new YourTransfersPage(_context);
            bool Test = yourTransfersPage.CheckPageTitle();
        }

        [When(@"I click on Create A Transfers Pledge")]
        public void WhenIClickOnCreateATransfersPledge()
        {
            YourTransfersPage yourTransfersPage = new YourTransfersPage(_context);
            yourTransfersPage.ClickCreateATransfersPledge();
            
        }

        [Then(@"I am on the Find A Business Page")]
        public void ThenIAmOnTheFindABusinessPage()
        {
            FindABusinessPage findABusinessPage = new FindABusinessPage(_context);
            bool Test = findABusinessPage.CheckPageTitle();
        }

        [When(@"I click on Continue")]
        public void WhenIClickOnContinue()
        {
            FindABusinessPage findABusinessPage = new FindABusinessPage(_context);
            findABusinessPage.ClickContinue();
        }

        [Then(@"I am on the Create A Transfers Pledge Page")]
        public void ThenIAmOnTheCreateATransfersPledgePage()
        {
            CreateATransfersPledgePage createATransfersPledge = new CreateATransfersPledgePage(_context);
            bool Test = createATransfersPledge.CheckPageTitle();
        }

        //new
        [When(@"I click on the Amount You Want To Pledge Link")]
        public void WhenIClickOnTheAmountYouWantToPledgeLink()
        {
            CreateATransfersPledgePage createATransfersPledge = new CreateATransfersPledgePage(_context);
            createATransfersPledge.ClickPledgeAmountLink();
        }

        [Then(@"I am on Pledge Amount And Org Name Page")]
        public void ThenIAmOnPledgeAmountAndOrgNamePage()
        {
            PledgeAmountAndOrgNamePage pledgeAmountAndOrgNamePage = new PledgeAmountAndOrgNamePage(_context);
            pledgeAmountAndOrgNamePage.CheckPageTitle();
        }

        [Then(@"I enter Transfer Amount of '(.*)'")]
        public void ThenIEnterTransferAmountOf(int p0)
        {
            PledgeAmountAndOrgNamePage pledgeAmountAndOrgNamePage = new PledgeAmountAndOrgNamePage(_context);
            pledgeAmountAndOrgNamePage.ClickPledgeAmountLink();
            pledgeAmountAndOrgNamePage.EnterPledgeAmount(p0);

        }

        [Then(@"I enter Transfer Amount using comma separator of '(.*)'")]
        public void ThenIEnterTransferAmountUsingCommaSeparatorOf(String p0)
        {
            PledgeAmountAndOrgNamePage pledgeAmountAndOrgNamePage = new PledgeAmountAndOrgNamePage(_context);
            pledgeAmountAndOrgNamePage.ClickPledgeAmountLink();
            pledgeAmountAndOrgNamePage.EnterPledgeAmount(p0);
        }


        [Then(@"I select '(.*)' to Organisation Name Shown Publicly")]
        public void ThenISelectToOrganisationNameShownPublicly(string p0)
        {
            PledgeAmountAndOrgNamePage pledgeAmountAndOrgNamePage = new PledgeAmountAndOrgNamePage(_context);
            pledgeAmountAndOrgNamePage.SelectIsNamePublicRadioButton(p0);
        }

        [When(@"I click on Pledge Amount Continue")]
        public void WhenIClickOnPledgeAmountContinue()
        {
            PledgeAmountAndOrgNamePage pledgeAmountAndOrgNamePage = new PledgeAmountAndOrgNamePage(_context);
            pledgeAmountAndOrgNamePage.ClickContinue();
        }

        [Then(@"the Submit Your Transfer Pledge Button is displayed")]
        public void ThenTheSubmitYourTransferPledgeButtonIsDisplayed()
        {
            CreateATransfersPledgePage createATransfersPledge = new CreateATransfersPledgePage(_context);
            createATransfersPledge.CheckSubmitButtonActivated();
        }

        [When(@"I click on Submit My Pledge")]
        public void WhenIClickOnSubmitMyPledge()
        {
            CreateATransfersPledgePage createATransfersPledge = new CreateATransfersPledgePage(_context);
            createATransfersPledge.ClickSubmitMyPledge();
        }

        [Then(@"I am on the Your Pledge Has Been Created Screen")]
        public void ThenIAmOnTheYourPledgeHasBeenCreatedScreen()
        {
            PledgeCreatedSuccessPage pledgeCreatedSuccessPage = new PledgeCreatedSuccessPage(_context);
            pledgeCreatedSuccessPage.CheckPagePanelTitle();

        }

        [Then(@"I store the newly created pledge ID")]
        public void ThenIStoreTheNewlyCreatedPledgeID()
        {
            PledgeCreatedSuccessPage pledgeCreatedSuccessPage = new PledgeCreatedSuccessPage(_context);
            newPledgeID = pledgeCreatedSuccessPage.GetNewPledgeID();
            
            TestContext.Progress.WriteLine(newPledgeID);
        }

        [When(@"I click on View Your Pledges")]
        public void WhenIClickOnViewYourPledges()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am taken to the My Transfer Pledges page")]
        public void ThenIAmTakenToTheMyTransferPledgesPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the created pledge appears on the page")]
        public void ThenTheCreatedPledgeAppearsOnThePage()
        {
            ScenarioContext.Current.Pending();
        }


    }
}


