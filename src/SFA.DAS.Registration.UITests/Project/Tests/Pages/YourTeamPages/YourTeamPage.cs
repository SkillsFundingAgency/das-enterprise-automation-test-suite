using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class YourTeamPage(ScenarioContext context, bool navigate = false) : InterimYourTeamPage(context, navigate)
    {
        #region Locators
        private static By InviteANewMemberButton => By.Id("addNewUser");
        private static By InvitationActionHeader => By.CssSelector(".das-notification__heading");

        #endregion

        public CreateInvitationPage ClickInviteANewMemberButton()
        {
            formCompletionHelper.Click(InviteANewMemberButton);
            return new CreateInvitationPage(context);
        }

        public AccessDeniedPage ClickInviteANewMemberButtonAndRedirectedToAccessDeniedPage()
        {
            formCompletionHelper.Click(InviteANewMemberButton);
            return new AccessDeniedPage(context);
        }

        public ViewTeamMemberPage ClickViewMemberLink(string email)
        {
            tableRowHelper.SelectRowFromTable("View", email);
            return new ViewTeamMemberPage(context);
        }

        public YourTeamPage VerifyInvitationResentHeaderInfoMessage()
        {
            VerifyInvitationActionHeader("Invitation resent");
            return this;
        }

        public YourTeamPage VerifyInvitationCancelledHeaderInfoMessage()
        {
            VerifyInvitationActionHeader("Invitation cancelled");
            return this;
        }

        public YourTeamPage VerifyTeamMemberRemovedHeaderInfoMessage()
        {
            VerifyInvitationActionHeader("Team member removed");
            return this;
        }

        private void VerifyInvitationActionHeader(string message) => VerifyElement(InvitationActionHeader, message);
    }
}
