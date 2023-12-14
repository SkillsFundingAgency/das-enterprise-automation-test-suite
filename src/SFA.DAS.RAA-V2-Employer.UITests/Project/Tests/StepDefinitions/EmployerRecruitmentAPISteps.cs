using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerRecruitmentAPISteps(ScenarioContext context)
    {
        private ApiListPage _apiListPage;
        private KeyforApiPage _keyforAPIPage;

        [Given(@"the employer selects the Recruitment API list page")]
        public void GivenTheEmployerSelectsTheRecruitmentAPIListPage() => _apiListPage = new YourApprenticeshipAdvertsHomePage(context).ClickRecruitmentAPILink().ClickAPIKeysHereLink();

        [When(@"the employer selects Recruitment API from the list")]

        public void WhenTheEmployerSelectsRecruitmentAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewRecruitmentAPILink();

        [When(@"the employer selects Recruitment Sandbox API from the list")]
        public void WhenTheEmployerSelectsRecruitmentSandboxAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewRecruitmentAPISandBoxLink();

        [When(@"the employer selects Display API from the list")]
        public void WhenTheEmployerSelectsDisplayAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewDisplayAPILink();

        [Then(@"the employer can renew the API key")]
        public void ThenTheEmployerCanRenewTheAPIKey() => _keyforAPIPage = _keyforAPIPage.ClickRenewKeyLink().RenewAPIKey().VerifyApikeyRenewed();
    }
}
