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
        #endregion

        public CreateInvitationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CreateInvitationPage EnterEmailAndFullName()
        {
            var email = registrationDataHelper.AnotherRandomEmail;
            formCompletionHelper.EnterText(EmailTextBox, email);
            objectContext.SetAnotherEmail(email);
            formCompletionHelper.EnterText(FullNameTextBox, registrationDataHelper.InvitedViewerAccessUserFullName);
            return this;
        }

        public InvitationSentPage SelectViewerAccessRadioButtonAndSendInvitation()
        {
            SelectRadioOptionByForAttribute("radio1");
            formCompletionHelper.Click(SendInvitationButton);
            return new InvitationSentPage(_context);
        }
    }
}
