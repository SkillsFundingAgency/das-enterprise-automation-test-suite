using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class CreateInvitationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create invitation";

        #region Locators
        private By SendInvitationButton => By.Id("send_invitation");
        private By EmailTextBox => By.Id("Email");
        private By FullNameTextBox => By.Id("Name");
        private By ViewerAccessRadioButton => By.Id("radio1");
        #endregion

        public CreateInvitationPage(ScenarioContext context) : base(context) => VerifyPage();

        public CreateInvitationPage EnterEmailAndFullName(string email)
        {
            formCompletionHelper.EnterText(EmailTextBox, email);
            formCompletionHelper.EnterText(FullNameTextBox, registrationDataHelper.FullName);
            return this;
        }

        public InvitationSentPage SelectViewerAccessRadioButtonAndSendInvitation()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewerAccessRadioButton));
            formCompletionHelper.Click(SendInvitationButton);
            return new InvitationSentPage(context);
        }
    }
}
