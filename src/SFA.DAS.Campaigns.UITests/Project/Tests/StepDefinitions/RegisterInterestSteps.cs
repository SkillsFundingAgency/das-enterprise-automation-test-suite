using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegisterInterestSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private  RegisterInterestPage registerInterestPage;
        private ScenarioContext _context;

        public RegisterInterestSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
            
        }

        //[Then(@"an apprentice registers interest")]
        //public void ThenAnApprenticeRegistersInterest() => NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Given(@"the employer navigates to Register Interest Page")]
        public void GivenTheEmployerNavigatesToRegisterInterestPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .NavigateToRegisterInterestPage();
        }
        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest()
        {
            registerInterestPage = new RegisterInterestPage(_context);
            registerInterestPage.RegisterInterest();
        }
    }
}
