using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TeamMemberSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private YourTeamPage _yourTeamPage;
        private readonly AccountSignOutHelper _accountSignOutHelper;
        private string _invitedMemberEmailId;

        public TeamMemberSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
        }

        [Then(@"Employer is able to invite a team member with Viewer access")]
        public void ThenEmployerIsAbleToInviteATeamMemberWithViewerAccess()
        {
            _invitedMemberEmailId = _registrationDataHelper.AnotherRandomEmail;

            _yourTeamPage = new HomePage(_context, true)
                .GotoYourTeamPage()
                .ClickInviteANewMemberButton()
                .EnterEmailAndFullName(_invitedMemberEmailId)
                .SelectViewerAccessRadioButtonAndSendInvitation()
                .GotoYourTeamPage();
        }

        [Then(@"Employer is able to resend an invite")]
        public void ThenEmployerIsAbleToResendAnInvite()
        {
            _yourTeamPage = _yourTeamPage.ClickViewMemberLink(_invitedMemberEmailId)
                .ClickResendInvitationButton()
                .VerifyInvitationResentHeaderInfoMessage();
        }

        [Then(@"Employer is able abort cancelling during cancelling an invite")]
        public void ThenEmployerIsAbleAbortCancellingDuringCancellingAnInvite()
        {
            _yourTeamPage = _yourTeamPage.ClickViewMemberLink(_invitedMemberEmailId)
                .ClickCancelInvitationLink()
                .ClickNoDontCancelInvitationLink();
        }

        [Then(@"Employer is able to cancel an invite")]
        public void ThenEmployerIsAbleToCancelAnInvite()
        {
            _yourTeamPage = _yourTeamPage.ClickViewMemberLink(_invitedMemberEmailId)
                .ClickCancelInvitationLink()
                .ClickYesCancelInvitationButtonButton()
                .VerifyInvitationCancelledHeaderInfoMessage();
        }

        [Then(@"the invited team member is able to accept the invite and login to the Employer account")]
        public void ThenTheInvitedTeamMemberIsAbleToAcceptTheInviteAndLoginToTheEmployerAccount()
        {
            ThenEmployerIsAbleToInviteATeamMemberWithViewerAccess();

            SignOut()
                .CreateAccount()
                .Register(_invitedMemberEmailId)
                .ContinueToInvitationsPage()
                .ClickAcceptInviteLink();
        }

        [Then(@"Employer is able to Remove the team member from the account")]
        public void ThenEmployerIsAbleToRemoveTheTeamMemberFromTheAccount()
        {
            SignOut()
                .ClickSignInLinkOnIndexPage()
                .Login(_objectContext.GetLoginCredentials())
                .GotoYourTeamPage()
                .ClickViewMemberLink(_invitedMemberEmailId)
                .ClickRemoveTeamMemberButton()
                .ClickYesRemoveNowButton()
                .VerifyTeamMemberRemovedHeaderInfoMessage();
        }

        private CreateAnAccountToManageApprenticeshipsPage SignOut() => _accountSignOutHelper.SignOut();
    }
}
