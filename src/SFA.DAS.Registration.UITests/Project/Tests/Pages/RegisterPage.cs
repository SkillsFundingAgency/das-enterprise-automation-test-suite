using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class RegisterPage : RegistrationBasePage
    {
        protected override string PageTitle => "Set up as a user";
        private readonly ScenarioContext _context;

        #region Locators
        private const string LastName = "Auto_Tester";
        private By FirstNameInput => By.Id("FirstName");
        private By LastNameInput => By.Id("LastName");
        private By EmailInput => By.Id("Email");
        private By PasswordInput => By.Id("Password");
        private By PasswordConfirmInput => By.Id("ConfirmPassword");
        private By SetMeUpButton => By.Id("button-register");
        #endregion

        public RegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmPage Register()
        {
            EnterFirstName().
            EnterlastName().
            EnterEmail().
            EnterPassword().
            EnterPasswordConfirm().
            SetMeUp();
            return new ConfirmPage(_context);
        }

        private RegisterPage EnterFirstName()
        {
            formCompletionHelper.EnterText(FirstNameInput, config.TwoDigitProjectCode);
            return this;
        }

        private RegisterPage EnterlastName()
        {
            formCompletionHelper.EnterText(LastNameInput, LastName);
            return this;
        }

        private RegisterPage EnterEmail()
        {
            formCompletionHelper.EnterText(EmailInput, registrationDataHelper.RandomEmail);
            return this;
        }

        private RegisterPage EnterPassword()
        {
            formCompletionHelper.EnterText(PasswordInput, registrationDataHelper.Password);
            return this;
        }

        private RegisterPage EnterPasswordConfirm()
        {
            formCompletionHelper.EnterText(PasswordConfirmInput, registrationDataHelper.Password);
            return this;
        }

        private RegisterPage SetMeUp()
        {
            formCompletionHelper.ClickElement(SetMeUpButton);
            return this;
        }
    }
}