using SFA.DAS.Campaigns.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_11Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        
        public CA_AP_11Steps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to How do they work Page")]
        public void GivenTheUserNavigatesToHowDoTheyWorkPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToApprenticeshipHubPage()
                .NavigateToHowDoTheyWorkPage();
        }
    }
}
