using NUnit.Framework;
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
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private string _invitedMemberEmailId;

        public TeamMemberSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
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
            TestContext.Progress.WriteLine($"Invited team member's email id: {_invitedMemberEmailId}");

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

            _accountCreationStepsHelper.SignOut()
                .CreateAccount()
                .Register(_invitedMemberEmailId)
                .EnterAccessCode()
                .ContinueToInvitationsPage()
                .ClickAcceptInviteLink();
        }

        [Then(@"Employer is able to Remove the team member from the account")]
        public void ThenEmployerIsAbleToRemoveTheTeamMemberFromTheAccount()
        {
            _accountCreationStepsHelper.SignOut()
                .SignIn()
                .Login(_objectContext.GetLoginCredentials())
                .GotoYourTeamPage()
                .ClickViewMemberLink(_invitedMemberEmailId)
                .ClickRemoveTeamMemberButton()
                .ClickYesRemoveNowButton()
                .VerifyTeamMemberRemovedHeaderInfoMessage();
        }
    }
}
