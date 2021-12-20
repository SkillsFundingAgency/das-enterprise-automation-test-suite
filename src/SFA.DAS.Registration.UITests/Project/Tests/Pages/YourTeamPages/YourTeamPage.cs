using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class YourTeamPage : InterimYourTeamPage
    {
        #region Locators
        private By InviteANewMemberButton => By.Id("addNewUser");
        private By ViewMemberLink(string email) => By.XPath($"//div[text()='{email}']/../..//td[@class='link-right']/a");
        private By InvitationActionHeader => By.CssSelector(".bold-large");
        #endregion

        public YourTeamPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => VerifyPage();

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
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ViewMemberLink(email)));
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
