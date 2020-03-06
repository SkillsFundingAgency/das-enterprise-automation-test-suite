using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsParentSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        public CampaignsParentSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [When(@"the user navigates to the their career page")]
        public void WhenTheUserNavigatesToTheTheirCareerPage() => _stepsHelper.GoToFireItUpHomePage().NavigateToParentHubPage().NavigateToTheirCareerPage();

    }
}
