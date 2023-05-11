using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SetUpAsAUserPage : RegistrationBasePage
    {
        protected override string PageTitle => "Set up as a user";

        #region constants
        private const string ExpectedEmailErrorText = "Email already registered.";
        private readonly string _password;
        #endregion

        #region Locators
        private By FirstNameInput(string value = null) => By.CssSelector($"#FirstName{value}");
        private By LastNameInput(string value = null) => By.CssSelector($"#LastName{value}");
        private By EmailInput(string value = null) => By.CssSelector($"#Email{value}");
        private By PasswordInput => By.Id("Password");
        private By PasswordConfirmInput => By.Id("ConfirmPassword");
        private By SetMeUpButton => By.Id("button-register");
        private By ErrorTextAboveEmailTextBox => By.Id("error-email");
        private By EmailErrorTextAtheader => By.CssSelector(".danger");
        private By SigninLink => By.LinkText("sign in");
        private By TermsAndConditionsLink => By.LinkText("terms of use");
        #endregion

        public SetUpAsAUserPage(ScenarioContext context) : base(context) { VerifyPage(); _password = registrationDataHelper.Password; }

        public ConfirmYourIdentityPage ProviderLeadRegistration()
        {
            string email = objectContext.GetRegisteredEmail();
            pageInteractionHelper.VerifyPage(FirstNameInput($"[value='{registrationDataHelper.FirstName}']"));
            pageInteractionHelper.VerifyPage(LastNameInput($"[value='{registrationDataHelper.LastName}']"));
            pageInteractionHelper.VerifyPage(EmailInput($"[value='{email.ToLower()}']"));

            EnterPassword().EnterPasswordConfirm().SetMeUp();

            return GoToConfirmYourIdentityPage(email);
        }

        public ConfirmYourIdentityPage Register(string email = null)
        {
            email = string.IsNullOrEmpty(email) ? objectContext.GetRegisteredEmail() : email;

            EnterRegistrationDetailsAndContinue(email);

            return GoToConfirmYourIdentityPage(email);
        }

        public void EnterRegistrationDetailsAndContinue(string email) => EnterFirstName().EnterlastName().EnterEmail(email).EnterPassword().EnterPasswordConfirm().SetMeUp();

        public void VerifyEmailAlreadyRegisteredErrorMessage()
        {
            pageInteractionHelper.VerifyText(EmailErrorTextAtheader, ExpectedEmailErrorText);
            pageInteractionHelper.VerifyText(ErrorTextAboveEmailTextBox, ExpectedEmailErrorText);
        }

        public SignInPage SignIn()
        {
            formCompletionHelper.ClickElement(SigninLink);
            return new SignInPage(context);
        }

        public TermsAndConditionsPage ClickTermsAndConditionsLink()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.Click(TermsAndConditionsLink));
            return new TermsAndConditionsPage(context);
        }

        private SetUpAsAUserPage EnterFirstName()
        {
            formCompletionHelper.EnterText(FirstNameInput(), registrationDataHelper.FirstName);
            return this;
        }

        private SetUpAsAUserPage EnterlastName()
        {
            formCompletionHelper.EnterText(LastNameInput(), registrationDataHelper.LastName);
            return this;
        }

        private SetUpAsAUserPage EnterEmail(string email)
        {
            formCompletionHelper.EnterText(EmailInput(), email);
            return this;
        }

        private SetUpAsAUserPage EnterPassword()
        {
            formCompletionHelper.EnterText(PasswordInput, _password);
            return this;
        }

        private SetUpAsAUserPage EnterPasswordConfirm()
        {
            formCompletionHelper.EnterText(PasswordConfirmInput, _password);
            return this;
        }

        private void SetMeUp() => formCompletionHelper.ClickElement(SetMeUpButton);

        private ConfirmYourIdentityPage GoToConfirmYourIdentityPage(string email) => new ConfirmYourIdentityPage(context, email, _password);
    }
}