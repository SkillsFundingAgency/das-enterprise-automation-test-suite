using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class InProgressApplication
    {
        private readonly ScenarioContext _context;
        private ApplicationOverviewPage _applicationOverviewPage;

        public InProgressApplication(ScenarioContext context) => _context = context;


        [When(@"a user with in progress application login")]
        public void WhenAUserWithInProgressApplicationLogin()
        {
            _applicationOverviewPage = new RoatpServiceStartPage(_context)
                .ClickApplyNow()
                .SelectOptionToSignInToASAccountAndContinue()
                .SubmitValidUserDetailsApplicationOverviewPage();
        }

        [Then(@"the application can be launched")]
        public void ThenTheApplicationCanBeLaunched() => _applicationOverviewPage.VerifyApplicationDetails();
    }
}
