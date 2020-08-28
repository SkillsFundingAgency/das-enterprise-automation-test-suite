using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_10Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        
        public CA_AP_10Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }

        [Given(@"the user navigates to Are ApprenticeShip Right For You Page")]
        public void GivenTheUserNavigatesToAreApprenticeShipRightForYouPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToApprenticeshipHubPage()
                .NavigateToAreApprenticeShipRightForMe();
        }
    }
}
