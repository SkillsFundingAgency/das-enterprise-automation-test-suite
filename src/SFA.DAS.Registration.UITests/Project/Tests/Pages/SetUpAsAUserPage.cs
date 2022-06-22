using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
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
        private By TermsAndConditionsLink => By.LinkText("terms and conditions");
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

        public void Register(UserDetails userDetails)
        {
            EnterFirstName(userDetails.FName)
                .EnterlastName(userDetails.LName)
                .EnterEmail(userDetails.Email)
                .EnterPassword(userDetails.Password)
                .EnterPasswordConfirm(userDetails.Confirmpassword)
                .SetMeUp();
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

        private SetUpAsAUserPage EnterFirstName() => EnterFirstName(registrationDataHelper.FirstName);

        private SetUpAsAUserPage EnterFirstName(string fname) 
        {
            EnterText(FirstNameInput(), fname);
            return this;
        }

        private SetUpAsAUserPage EnterlastName() => EnterlastName(registrationDataHelper.LastName);

        private SetUpAsAUserPage EnterlastName(string lName)
        {
            EnterText(LastNameInput(), lName);
            return this;
        }

        private SetUpAsAUserPage EnterEmail(string email)
        {
            EnterText(EmailInput(), email);
            return this;
        }

        private SetUpAsAUserPage EnterPassword() => EnterPassword(_password);

        private SetUpAsAUserPage EnterPassword(string password)
        {
            EnterText(PasswordInput, password);
            return this;
        }

        private SetUpAsAUserPage EnterPasswordConfirm() => EnterPasswordConfirm(_password);

        private SetUpAsAUserPage EnterPasswordConfirm(string password)
        {
            EnterText(PasswordConfirmInput, password);
            return this;
        }

        private void EnterText(By by, string text) => formCompletionHelper.EnterText(by, text);

        private void SetMeUp() => formCompletionHelper.ClickElement(SetMeUpButton);

        private ConfirmYourIdentityPage GoToConfirmYourIdentityPage(string email) => new ConfirmYourIdentityPage(context, email, _password);
    }
}