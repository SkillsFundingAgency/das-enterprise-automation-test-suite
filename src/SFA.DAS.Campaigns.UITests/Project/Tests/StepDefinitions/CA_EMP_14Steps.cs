using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CA_EMP_14Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;

        public CA_EMP_14Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to How Do They Work Page")]
        public void GivenTheUserNavigatesToHowDoTheyWorkPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .ClickHowDoTheyWorkLink();
        }
        
        [Given(@"Verify the content on How Do They Work Page")]
        public void GivenVerifyTheContentOnHowDoTheyWorkPage()
        { }
    }
}
