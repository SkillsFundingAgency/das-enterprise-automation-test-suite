using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class CancelInvitationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Cancel invitation";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesCancelInvitationButton => By.Id("cancel_invitation");
        private By NoDontCancelInvitationLink => By.LinkText("No, don't cancel invitation");
        #endregion

        public CancelInvitationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourTeamPage ClickYesCancelInvitationButtonButton()
        {
            formCompletionHelper.Click(YesCancelInvitationButton);
            return new YourTeamPage(_context);
        }

        public YourTeamPage ClickNoDontCancelInvitationLink()
        {
            formCompletionHelper.Click(NoDontCancelInvitationLink);
            return new YourTeamPage(_context);
        }
    }
}
