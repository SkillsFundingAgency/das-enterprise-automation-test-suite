using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CA_EMP_10Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        private HowDoTheyWorkPage _howDoTheyWorkPage;
        //private EmployerFavouritesPage _empFavpage;
        //private GovUkYourSavedFavouritesPage _govukFavpage;
        //private SummaryOfThisApprenticeshipPage _appsummaryPage;
        //private SummaryOfThisProviderPage _providersummaryPage;
        //private SignInPage _signInPage;
        //private readonly CampaignsDataHelper _campaignsDataHelper;
        //private readonly TabHelper _tabHelper;
        //private readonly CampaignsConfig _campaignsConfig;
        //private readonly ObjectContext _objectContext;
        public CA_EMP_10Steps(ScenarioContext context) 
        {
            _context = context;
            //_objectContext = context.Get<ObjectContext>();
            _stepsHelper = new CampaignsStepsHelper(context);
            //_campaignsDataHelper = context.Get<CampaignsDataHelper>();
            //_tabHelper = context.Get<TabHelper>();
            //_campaignsConfig = context.GetCampaignsConfig<CampaignsConfig>();
        }

        [Given(@"the user navigates to the How do they work page")]

        public void GivenTheUserNavigatesToTheHowDoTheyWorkPage()
        {
            //pDevelop How thye work page
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .ClickHowDoTheyWorkLink();

        }

        [Then(@"verify the links are not broken on How do they work page")]
        public void ThenVerifyTheLinksAreNotBrokenOnHowDoTheyWorkPage()
        {
            _howDoTheyWorkPage = new HowDoTheyWorkPage(_context);
            _howDoTheyWorkPage.CheckHiringAnApprenticeIconPage()
                .ClickHowDoTheyWorkLink()
                .CheckUpSkillingYourCurrentStaffPage()
                .ClickHowDoTheyWorkLink()
                .CheckFundingAnApprenticeshipPage()
                .ClickHowDoTheyWorkLink()
                .CheckTrainYourApprenticePage()
                .ClickHowDoTheyWorkLink()
                //.CheckEndPointAssessmentPage();
                .NavigateToEndPointAssesmentPage();
         

        }

    }
}
