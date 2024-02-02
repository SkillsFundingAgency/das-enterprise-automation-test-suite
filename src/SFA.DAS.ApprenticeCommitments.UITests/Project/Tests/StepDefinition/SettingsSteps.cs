using Polly;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Mailinator.Service.Project.Helpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps(ScenarioContext context) : BaseSteps(context)
    {
        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their email")]
        public void ThenAnApprenticeCanChangeTheirEmail() => UpdateEmailAddress().ReturnToHome().SignOutFromTheService().ClickSignBackInLinkFromSignOutPage().SignInWithUpdatedEmail();

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
        public void ThenAnApprenticeChangeTheirPersonalDetailsMenuIsAvailable() => new CreateMyApprenticeshipAccountPage(context).NavigateToChangeYourPersonalDetails();

        private PasswordResetSuccessfulPage UpdatePassword()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourPassword().RequestToUpdatePassword();
            NavigateToMailinatorClickOnNotificationLink(objectContext.GetApprenticeEmail(), "Password reset for My apprenticeship", "change your password");
            return new ResetPasswordPage(context).UpdatePassword();
        }

        private YouHaveUpdatedYourEmailAddressPage UpdateEmailAddress()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourEmailAddress().RequestToUpdateEmailAddress();
            NavigateToMailinatorClickOnNotificationLink(objectContext.GetApprenticeChangedEmail(), "Confirm your new email address", "Verify email address");
            return new ChangeYourEmailAddressPage(context).UpdateEmailAddress();
        }

        private void NavigateToMailinatorClickOnNotificationLink(string email, string subject, string linkText)
        {
            var link = context.Get<MailosaurApiHelper>().GetLinkBySubject(email, subject, linkText);

            tabHelper.OpenInNewTab(link);
        }


        private TopBannerSettingsPage GetTopBannerSettingsPage() => new(context);
    }
}
