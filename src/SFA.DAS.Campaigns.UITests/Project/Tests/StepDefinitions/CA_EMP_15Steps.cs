using SFA.DAS.Campaigns.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CA_EMP_15Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;

        public CA_EMP_15Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Setting Up Page")]
        public void GivenTheUserNavigatesToSettingUpPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                 .NavigateToEmployerHubPage()
                 .ClickSettingUpLink();
        }
        
        [Given(@"Verify the content on Setting Up Page")]
        public void GivenVerifyTheContentOnSettingUpPage()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
