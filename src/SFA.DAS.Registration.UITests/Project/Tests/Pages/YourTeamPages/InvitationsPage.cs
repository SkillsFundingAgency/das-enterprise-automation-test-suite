using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class InvitationsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Invitations";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By AcceptInviteLink => By.Id("invitationId");
        #endregion

        public InvitationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage ClickAcceptInviteLink()
        {
            formCompletionHelper.Click(AcceptInviteLink);
            return new HomePage(context);
        }
    }
}
