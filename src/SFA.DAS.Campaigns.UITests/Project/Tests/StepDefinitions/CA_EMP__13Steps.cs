using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Employer
{
    [Binding]
    public class CA_EMP__13Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;

        public CA_EMP__13Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Are they right for you Page")]
        public void GivenTheUserNavigatesToAreTheyRightForYouPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .NavigateToAreTheyRightForYouPage();
               
        }
    }
}
