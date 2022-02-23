using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RecruitmentAPISteps
    {
        private readonly ScenarioContext _context;
        private YourApprenticeshipAdvertsHomePage _yourApprenticeshipAdvertsHomePage;
        private GetStartedWithRecruitmentAPIsPage _getStartedWithRecruitmentAPIsPage;
        private APIListPage _aPIListPage;
        private KeyforAPIPage _keyforAPIPage;
        private AreYouSureYouWantToRenewThisAPIKeyPage _areYouSureYouWantToRenewThisAPIKeyPage;

        public RecruitmentAPISteps(ScenarioContext context)
        {
            _context = context;
            _yourApprenticeshipAdvertsHomePage = new YourApprenticeshipAdvertsHomePage(_context);
        }

        [Given(@"the employer selects the Recruitment API list page")]
        public void GivenTheEmployerSelectsTheRecruitmentAPIListPage()
        {
            _getStartedWithRecruitmentAPIsPage = _yourApprenticeshipAdvertsHomePage.ClickRecruitmentAPILink();
            _aPIListPage = _getStartedWithRecruitmentAPIsPage.ClickAPIKeysHereLinkLink();
        }

        [When(@"the employer selects Recruitment API from the list")]
        
        public void WhenTheEmployerSelectsRecruitmentAPIFromTheList()
        {
            _keyforAPIPage = _aPIListPage.ClickViewRecruitmentAPILink();
        }

        [When(@"the employer selects Recruitment Sandbox API from the list")]
        public void WhenTheEmployerSelectsRecruitmentSandboxAPIFromTheList()
        {
            _keyforAPIPage = _aPIListPage.ClickViewRecruitmentAPISandBoxLink();
        }

        [When(@"the employer selects Display API from the list")]
        public void WhenTheEmployerSelectsDisplayAPIFromTheList()
        {
            _keyforAPIPage = _aPIListPage.ClickViewDisplayAPILink();
        }

        [Then(@"the employer can renew the API key")]
        public void ThenTheEmployerCanRenewTheAPIKey()
        {
            _keyforAPIPage.ClickDoYouNeedANewKeyDropDown();
            _areYouSureYouWantToRenewThisAPIKeyPage = _keyforAPIPage.ClickRenewKeyLink();
            _areYouSureYouWantToRenewThisAPIKeyPage.SelectYesToRenewAPIKey();
            _keyforAPIPage = _areYouSureYouWantToRenewThisAPIKeyPage.ClickContinueToRenewKey();
        }

    }
}
