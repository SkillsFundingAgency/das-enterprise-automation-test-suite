using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsHomeSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        private ApprenticeHubPage _apprenticeHubPage;

        private EmployerHubPage _employerHubPage;

        public CampaignsHomeSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to Home page and verifies the content")]
        public void GivenTheUserNavigatesToHomePageAndVerifiesTheContent() => _stepsHelper.GoToCampaingnsHomePage();

        [Given(@"the user navigates to the employer page")]
        public void GivenTheUserNavigatesToTheEmployerPage() => _employerHubPage = _stepsHelper.GoToEmployerHubPage();

        [Given(@"the user navigates to the apprentice page")]
        public void GivenTheUserNavigatesToTheApprenticePage() => _apprenticeHubPage = _stepsHelper.GoToApprenticeshipHubPage();

        [Then(@"the fire it up tile card links are not broken")]
        public void ThenTheFireItUpTileCardLinksAreNotBroken()
        {
            _apprenticeHubPage?.VerifySubHeadings();

            _employerHubPage?.VerifySubHeadings();
        }

    }
}
