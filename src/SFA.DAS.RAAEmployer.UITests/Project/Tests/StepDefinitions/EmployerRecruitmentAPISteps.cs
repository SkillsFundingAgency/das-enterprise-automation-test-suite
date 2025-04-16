using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerRecruitmentAPISteps(ScenarioContext context)
    {
        private ApiListPage _apiListPage;
        private KeyforApiPage _keyforAPIPage;

        [When(@"the employer selects the Recruitment API list page")]
        [Given(@"the employer selects the Recruitment API list page")]
        public void GivenTheEmployerSelectsTheRecruitmentAPIListPage() => _apiListPage = new YourApprenticeshipAdvertsHomePage(context).ClickRecruitmentAPILink().ClickAPIKeysHereLink();

        [Then(@"the employer selects Recruitment API from the list")]
        [When(@"the employer selects Recruitment API from the list")]

        public void WhenTheEmployerSelectsRecruitmentAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewRecruitmentAPILink();

        [When(@"the Employer navigates to 'Recruit dashboard' Page")]
        public void WhenTheEmployerNavigatesToRecruitDashboardPage() => _apiListPage = new VacancyConfirmationPage(context).ClickReturnToDashboard().ClickRecruitmentAPILink().ClickAPIKeysHereLink();

        [When(@"the employer selects Recruitment Sandbox API from the list")]
        public void WhenTheEmployerSelectsRecruitmentSandboxAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewRecruitmentAPISandBoxLink();

        [When(@"the employer selects Display API from the list")]
        public void WhenTheEmployerSelectsDisplayAPIFromTheList() => _keyforAPIPage = _apiListPage.ClickViewDisplayAPILink();

        [Then(@"the employer can renew the API key")]
        public void ThenTheEmployerCanRenewTheAPIKey() => _keyforAPIPage = _keyforAPIPage.ClickRenewKeyLink().RenewAPIKey().VerifyApikeyRenewed();

        [When(@"the employer navigates to Adverts page")]
        public void ThenTheEmployerNavigatesToAdvertsPage() => _keyforAPIPage.ClickAdvertsLink();

        [Then(@"the employer selects the 'Manage your emails' link")]
        public void ThenTheEmployerSelectsTheManageYourEmailsLink() => new YourApprenticeshipAdvertsHomePage(context).ClickMangeYourEmailsLink();
    }
}
