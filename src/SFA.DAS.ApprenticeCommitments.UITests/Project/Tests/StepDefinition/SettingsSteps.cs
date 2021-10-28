using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps : BaseSteps
    {
        private ApprenticeOverviewPage _apprenticeOverviewPage;

        public SettingsSteps(ScenarioContext context) : base(context) { }

        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => _apprenticeOverviewPage = createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their email")]
        public void ThenAnApprenticeCanChangeTheirEmail() => _apprenticeOverviewPage.NavigateToChangeYourEmailAddress().UpdateEmailAddress();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails() => _apprenticeOverviewPage.NavigateToChangeYourPersonalDetails().UpdateApprenticeName();

        [Then(@"an apprentice can change their password")]
        public void ThenAnApprenticeCanChangeTheirPassword() => _apprenticeOverviewPage.NavigateToChangeYourPassword().UpdatePassword();
    }
}
