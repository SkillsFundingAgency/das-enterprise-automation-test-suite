using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_AreTheyRightForYouSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private AreApprenticeShipRightForMePage areApprenticeShipRightForMePage;
        private readonly ScenarioContext _context;
        
        public CA_AP_AreTheyRightForYouSteps(ScenarioContext context)
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
        [Then(@"check that RealStories Page loads")]
        public void ThenCheckThatRealStoriesPageLoads()
        {
            areApprenticeShipRightForMePage = new AreApprenticeShipRightForMePage(_context);
            areApprenticeShipRightForMePage.NavigateToRealStoriesPage();

        }
    }
}
