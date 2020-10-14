using SFA.DAS.Campaigns.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsHomeSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        public CampaignsHomeSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to Home page and verifies the content")]
        public void GivenTheUserNavigatesToHomePageAndVerifiesTheContent() => _stepsHelper.GoToFireItUpHomePage();
    }
}
