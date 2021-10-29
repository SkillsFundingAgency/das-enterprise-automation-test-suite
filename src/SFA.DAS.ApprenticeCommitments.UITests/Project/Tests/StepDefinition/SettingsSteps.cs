using NUnit.Framework;
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
        public void ThenAnApprenticeCanChangeTheirEmail() => UpdateEmailAddress().ReturnToMyApprenticeship();

        [Then(@"an apprentice can change their email before confirming account")]
        public void ThenAnApprenticeCanChangeTheirEmailBeforeConfirmingAccount() => UpdateEmailAddress().ReturnToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails() => GetTopBannerSettingsPage().NavigateToChangeYourPersonalDetails().UpdateApprenticeName();

        [Then(@"an apprentice can change their password")]
        public void ThenAnApprenticeCanChangeTheirPassword() => UpdatePassword().ReturnToMyApprenticeship();

        [Then(@"an apprentice can change their password before confirming account")]
        public void ThenAnApprenticeCanChangeTheirPasswordBeforeConfirmingAccount() => UpdatePassword().ReturnToCreateMyApprenticeshipAccountPage().ConfirmIdentityAndGoToTermsOfUsePage();

        [Then(@"an apprentice can not change their personal details")]
        public void ThenAnApprenticeCanNotChangeTheirPersonalDetails()
        {
            var page = new CreateMyApprenticeshipAccountPage(_context);

            var expected = page.AccountSettingList();

            var actual = new CreateMyApprenticeshipAccountPage(_context).GetAccountSettingMenuList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private PasswordResetSuccessfulPage UpdatePassword()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourPassword().RequestToUpdatePassword();

            OpenLink("https://login");

            return new ResetPasswordPage(_context).UpdatePassword();
        }

        private YouHaveUpdatedYourEmailAddressPage UpdateEmailAddress()
        {
            GetTopBannerSettingsPage().NavigateToChangeYourEmailAddress().RequestToUpdateEmailAddress();

            OpenLink("https://confirm.");

            return new ChangeYourEmailAddressPage(_context).UpdateEmailAddress();
        }

        private void OpenLink(string linkText) => new MailinatorStepsHelper(_context, objectContext.GetApprenticeEmail()).OpenLink(linkText);

        private TopBannerSettingsPage GetTopBannerSettingsPage() => new TopBannerSettingsPage(_context);

    }
}
