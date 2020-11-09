using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class InProgressApplication
    {
        private readonly RoatpApplyLoginHelpers _roatpApplyLoginHelpers;
        private ApplicationOverviewPage _applicationOverviewPage;

        public InProgressApplication(ScenarioContext context) => _roatpApplyLoginHelpers = new RoatpApplyLoginHelpers(context);


        [When(@"a user with in progress application login")]
        public void WhenAUserWithInProgressApplicationLogin() => _applicationOverviewPage = _roatpApplyLoginHelpers.SignInToRegisterPage().SubmitValidUserDetailsApplicationOverviewPage();

        [Then(@"the application can be launched")]
        public void ThenTheApplicationCanBeLaunched() => _applicationOverviewPage.VerifyApplicationDetails();
    }
}
