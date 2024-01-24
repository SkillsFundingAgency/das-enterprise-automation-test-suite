using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class UnHappyPathSteps(ScenarioContext context)
    {
        private ApplicationOverviewPage _overviewPage;

        [When(@"the provider selects the unhappy path")]
        public void WhenTheProviderSelectsTheUnhappyPath() => _overviewPage = RoatpApplyEnd2EndStepsHelper.CompleteSecion1_UnHappyPath(new ApplicationOverviewPage(context));

        [Then(@"the provider cannot continue the journey")]
        public void ThenTheProviderCannotContinueTheJourney() => _overviewPage.VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusInProgress);
    }
}
