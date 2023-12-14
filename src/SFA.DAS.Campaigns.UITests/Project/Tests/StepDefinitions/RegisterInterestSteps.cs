using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegisterInterestSteps(ScenarioContext context)
    {
        private readonly CampaignsStepsHelper _stepsHelper = new CampaignsStepsHelper(context);

        private  RegisterInterestPage _registerInterestPage;

        [Given(@"the employer navigates to Register Interest Page")]
        public void GivenTheEmployerNavigatesToRegisterInterestPage() => _registerInterestPage = _stepsHelper.GoToEmployerHubPage().NavigateToRegisterInterestPage();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => _registerInterestPage.RegisterInterest();
    }
}
