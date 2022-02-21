using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Mailinator.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps : BaseSteps
    {
        private readonly ScenarioContext _context;

        public SettingsSteps(ScenarioContext context) : base(context)  => _context = context;

        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their email")]
        public void ThenAnApprenticeCanChangeTheirEmail() => UpdateEmailAddress().ReturnToHome();

        [Then(@"an apprentice can change their email before confirming account")]
        public void ThenAnApprenticeCanChangeTheirEmailBeforeConfirmingAccount() => UpdateEmailAddress().ReturnToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourPersonalDetails().UpdateApprenticeName();
            // DOB fields were disabled after a successful match before, but in Sprint28 AccoutsWeb rework, DOB field is made Editable.
        }

        [Then(@"an apprentice can change their password")]
        public void ThenAnApprenticeCanChangeTheirPassword() => UpdatePassword().ReturnToHome();

        [Then(@"an apprentice can change their password before confirming account")]
        public void ThenAnApprenticeCanChangeTheirPasswordBeforeConfirmingAccount() => UpdatePassword().ReturnToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage();

        [Then(@"an apprentice change their personal details menu is available")]
        public void ThenAnApprenticeChangeTheirPersonalDetailsMenuIsAvailable() => new CreateMyApprenticeshipAccountPage(_context).NavigateToChangeYourPersonalDetails();

        private PasswordResetSuccessfulPage UpdatePassword()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourPassword().RequestToUpdatePassword();
            NavigateToMailinatorClickOnNotificationLink("change your password");
            return new ResetPasswordPage(_context).UpdatePassword();
        }

        private YouHaveUpdatedYourEmailAddressPage UpdateEmailAddress()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourEmailAddress().RequestToUpdateEmailAddress();
            NavigateToMailinatorClickOnNotificationLink("Verify email address");
            return new ChangeYourEmailAddressPage(_context).UpdateEmailAddress();
        }

        private void NavigateToMailinatorClickOnNotificationLink(string linkText) => new MailinatorStepsHelper(_context, objectContext.GetApprenticeEmail()).OpenLink(linkText);

        private TopBannerSettingsPage GetTopBannerSettingsPage() => new TopBannerSettingsPage(_context);
    }
}
