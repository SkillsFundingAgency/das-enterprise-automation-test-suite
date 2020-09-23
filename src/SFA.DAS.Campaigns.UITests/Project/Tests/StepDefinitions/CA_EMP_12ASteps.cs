using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CA_EMP_12ASteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
       
        public CA_EMP_12ASteps(ScenarioContext context)
        {
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Hire An Apprentice hub Page")]
        public void GivenTheUserNavigatesToHireAnApprenticeHubPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage();
        }
    }
}
