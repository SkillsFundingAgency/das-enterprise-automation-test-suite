using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class ViewTeamMemberPage : RegistrationBasePage
    {
        protected override string PageTitle => registrationDataHelper.FullName;
        private readonly ScenarioContext _context;

        #region Locators
        private By ResendInvitationButton => By.Id("resend_invitation");
        private By CancelInvitationLink => By.LinkText("Cancel Invitation");
        private By RemoveTeamMemberButton => By.Id("delete_user");
        #endregion

        public ViewTeamMemberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourTeamPage ClickResendInvitationButton()
        {
            formCompletionHelper.Click(ResendInvitationButton);
            return new YourTeamPage(_context);
        }

        public CancelInvitationPage ClickCancelInvitationLink()
        {
            formCompletionHelper.Click(CancelInvitationLink);
            return new CancelInvitationPage(_context);
        }

        public RemoveTeamMemberPage ClickRemoveTeamMemberButton()
        {
            formCompletionHelper.Click(RemoveTeamMemberButton);
            return new RemoveTeamMemberPage(_context);
        }
    }
}
