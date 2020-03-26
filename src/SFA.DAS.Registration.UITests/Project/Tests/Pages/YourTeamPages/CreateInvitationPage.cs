using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class CreateInvitationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create invitation";
        private readonly ScenarioContext _context;

        #region Locators
        private By SendInvitationButton => By.Id("send_invitation");
        private By EmailTextBox => By.Id("Email");
        private By FullNameTextBox => By.Id("Name");
        private By ViewerAccessRadioButton => By.Id("radio1");
        #endregion

        public CreateInvitationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CreateInvitationPage EnterEmailAndFullName(string email)
        {
            formCompletionHelper.EnterText(EmailTextBox, email);
            objectContext.SetAnotherEmail(email);
            formCompletionHelper.EnterText(FullNameTextBox, registrationDataHelper.InvitedViewerAccessUserFullName);
            return this;
        }

        public InvitationSentPage SelectViewerAccessRadioButtonAndSendInvitation()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewerAccessRadioButton));
            formCompletionHelper.Click(SendInvitationButton);
            return new InvitationSentPage(_context);
        }
    }
}
