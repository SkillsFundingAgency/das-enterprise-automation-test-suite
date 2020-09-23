using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CA_EMP_10Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        public CA_EMP_10Steps(ScenarioContext context) 
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }

        [Given(@"the user navigates to the How do they work page")]

        public void GivenTheUserNavigatesToTheHowDoTheyWorkPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .ClickHowDoTheyWorkLink();
        }
    }
}
