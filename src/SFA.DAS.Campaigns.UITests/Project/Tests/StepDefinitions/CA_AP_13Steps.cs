using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CA_AP_13Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        public CA_AP_13Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }

        [Given(@"the user navigates to Home page and verifies the content")]
        public void GivenTheUserNavigatesToHomePageAndVerifiesTheContent()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .VerifyFiuHomePageCard1()
                .VerifyFiuHomePageCard2()
                .VerifyFiuHomePageCard3()
                .VerifyFiuHomePageCard4();
        }
    }
}
