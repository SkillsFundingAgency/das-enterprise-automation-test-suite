using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps(ScenarioContext context) : BaseSteps(context)
    {
        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails()
        {
            new TopBannerSettingsPage(context).NavigateToChangeYourPersonalDetails().UpdateApprenticeName();
            // DOB fields were disabled after a successful match before, but in Sprint28 AccoutsWeb rework, DOB field is made Editable.
        }

        [Then(@"an apprentice change their personal details menu is available")]
        public void ThenAnApprenticeChangeTheirPersonalDetailsMenuIsAvailable() => new CreateMyApprenticeshipAccountPage(context).NavigateToChangeYourPersonalDetails();

    }
}
