using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class ViewTeamMemberPage : RegistrationBasePage
    {
        protected override string PageTitle => registrationDataHelper.FullName;

        protected override string AccessibilityPageTitle => "View team member page";

        #region Locators
        private static By ResendInvitationButton => By.Id("resend_invitation");
        private static By CancelInvitationLink => By.LinkText("Cancel invitation");
        private static By RemoveTeamMemberButton => By.Id("delete_user");
        #endregion

        public ViewTeamMemberPage(ScenarioContext context) : base(context) => VerifyPage();

        public YourTeamPage ClickResendInvitationButton()
        {
            formCompletionHelper.Click(ResendInvitationButton);
            return new YourTeamPage(context);
        }

        public CancelInvitationPage ClickCancelInvitationLink()
        {
            formCompletionHelper.Click(CancelInvitationLink);
            return new CancelInvitationPage(context);
        }

        public RemoveTeamMemberPage ClickRemoveTeamMemberButton()
        {
            formCompletionHelper.Click(RemoveTeamMemberButton);
            return new RemoveTeamMemberPage(context);
        }
    }
}
