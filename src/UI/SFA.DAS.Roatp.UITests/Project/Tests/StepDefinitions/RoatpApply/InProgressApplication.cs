using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class InProgressApplication(ScenarioContext context)
    {
        [When(@"a user with in progress application login")]
        public void WhenAUserWithInProgressApplicationLogin() => new RoatpApplyLoginHelpers(context).SubmitValidUserDetails();

        [Then(@"the user will be directed to their current application")]
        public void ThenTheUserWillBeDirectedToTheirCurrentApplication() => new ApplicationOverviewPage(context).VerifyApplicationDetails();
    }
}
