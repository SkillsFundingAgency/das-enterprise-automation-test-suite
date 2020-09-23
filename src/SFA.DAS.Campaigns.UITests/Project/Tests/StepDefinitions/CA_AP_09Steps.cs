using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_09Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        public CA_AP_09Steps(ScenarioContext context)
        {
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Become An Apprentice page")]
        public void GivenTheUserNavigatesToBecomeAnApprenticePage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToApprenticeshipHubPage();
        }
    }
}
