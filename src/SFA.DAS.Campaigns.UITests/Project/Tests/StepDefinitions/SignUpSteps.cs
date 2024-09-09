using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SignUpSteps(ScenarioContext context)
    {
        private readonly CampaignsStepsHelper _stepsHelper = new(context);

        private SignUpPage _signUpPage;

        [Given(@"the employer navigates to Sign Up Page")]
        public void GivenTheEmployerNavigatesToSignUpPage() => _signUpPage = _stepsHelper.GoToEmployerHubPage().NavigateToSignUpPage();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => _signUpPage.EnterPersonalDetails().RegisterInterest();
    }
}
