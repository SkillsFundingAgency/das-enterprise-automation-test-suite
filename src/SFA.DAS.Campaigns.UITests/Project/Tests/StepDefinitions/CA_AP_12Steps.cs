using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_12Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;

        public CA_AP_12Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }

        [Given(@"the user navigates to Getting started Page")]
        public void GivenTheUserNavigatesToGettingStartedPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
               .NavigateToApprenticeshipHubPage()
               .NavigateToGettingStarted();

               
        }
    }
}
