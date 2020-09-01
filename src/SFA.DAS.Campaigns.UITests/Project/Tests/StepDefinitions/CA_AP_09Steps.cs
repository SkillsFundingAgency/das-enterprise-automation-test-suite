using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_09Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        public CA_AP_09Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Become An Apprentice page")]
        public void GivenTheUserNavigatesToBecomeAnApprenticePage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToApprenticeshipHubPage();
        }
        [Given(@"Verify the content on Become An Apprentice Page")]
        public void GivenVerifyTheContentOnBecomeAnApprenticePage()
        {
           // ScenarioContext.Current.Pending();
        }

    }
}
