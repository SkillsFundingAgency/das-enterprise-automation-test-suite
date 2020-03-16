using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SetUpAsAUserPage : RegistrationBasePage
    {
        protected override string PageTitle => "Set up as a user";
        private readonly ScenarioContext _context;

        #region constants
        private const string LastName = "Auto_Tester";
        private const string ExpectedEmailErrorText = "Email already registered.";
        #endregion

        #region Locators
        private By FirstNameInput => By.Id("FirstName");
        private By LastNameInput => By.Id("LastName");
        private By EmailInput => By.Id("Email");
        private By PasswordInput => By.Id("Password");
        private By PasswordConfirmInput => By.Id("ConfirmPassword");
        private By SetMeUpButton => By.Id("button-register");
        private By ErrorTextAboveEmailTextBox => By.Id("error-email");
        private By EmailErrorTextAtheader => By.CssSelector(".danger");
        #endregion

        public SetUpAsAUserPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmPage Register()
        {
            EnterRegistrationDetailsAndContinue(objectContext.GetRegisteredEmail());
            return new ConfirmPage(_context);
        }

        public SetUpAsAUserPage EnterRegistrationDetailsAndContinue(string email)
        {
            EnterFirstName().
            EnterlastName().
            EnterEmail(email).
            EnterPassword().
            EnterPasswordConfirm().
            SetMeUp();
            return this;
        }

        public void VerifyEmailAlreadyRegisteredErrorMessage()
        {
            pageInteractionHelper.VerifyText(EmailErrorTextAtheader, ExpectedEmailErrorText);
            pageInteractionHelper.VerifyText(ErrorTextAboveEmailTextBox, ExpectedEmailErrorText);
        }

        private SetUpAsAUserPage EnterFirstName()
        {
            formCompletionHelper.EnterText(FirstNameInput, config.TwoDigitProjectCode);
            return this;
        }

        private SetUpAsAUserPage EnterlastName()
        {
            formCompletionHelper.EnterText(LastNameInput, LastName);
            return this;
        }

        private SetUpAsAUserPage EnterEmail(string email)
        {
            formCompletionHelper.EnterText(EmailInput, email);
            return this;
        }

        private SetUpAsAUserPage EnterPassword()
        {
            formCompletionHelper.EnterText(PasswordInput, registrationDataHelper.Password);
            return this;
        }

        private SetUpAsAUserPage EnterPasswordConfirm()
        {
            formCompletionHelper.EnterText(PasswordConfirmInput, registrationDataHelper.Password);
            return this;
        }

        private SetUpAsAUserPage SetMeUp()
        {
            formCompletionHelper.ClickElement(SetMeUpButton);
            return this;
        }
    }
}