using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegisterInterestSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        public RegisterInterestSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Then(@"an apprentice registers interest")]
        public void ThenAnApprenticeRegistersInterest() => NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => NavigateToRegisterInterest().RegisterInterestAsAnEmployer().VerifyDetail();

        private RegisterInterestPage NavigateToRegisterInterest() => _stepsHelper.GoToFireItUpHomePage().NavigateToRegisterInterest();
    }
}
