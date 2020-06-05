using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RegistrationPage : RAAV1BasePage
    {
        protected override By PageHeader => By.CssSelector(".pageTitle");

        protected override string PageTitle => "Registration";

        private By Title => By.Id("title");
        private By FirstName => By.Id("firstName");
        private By LastName => By.Id("lastName");
        private By EmailAddress => By.Id("userEmail");
        private By MobileNumber => By.Id("userMobile");
        private By Password => By.Id("password");
        private By ConfirmPassword => By.Id("confirmPassword");
        private By AcceptTermsAndCondition => By.CssSelector("label[for='termsAndConditions']");
        private By ButtonRegister => By.CssSelector(".form-buttons .btn");
        private By ConfirmationText => By.CssSelector(".pageSubtitle");

        public RAA_RegistrationPage(ScenarioContext context) : base(context) { }

        public RAA_RegistrationPage Register()
        {
            formCompletionHelper.SelectFromDropDownByText(Title, rAAV1RegistrationDataHelper.Title);
            formCompletionHelper.EnterText(FirstName, rAAV1RegistrationDataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, rAAV1RegistrationDataHelper.LastName);
            formCompletionHelper.EnterText(EmailAddress, rAAV1RegistrationDataHelper.EmailAddress);
            formCompletionHelper.EnterText(MobileNumber, rAAV1RegistrationDataHelper.MobileNumber);
            formCompletionHelper.EnterText(Password, rAAV1RegistrationDataHelper.Password);
            formCompletionHelper.EnterText(ConfirmPassword, rAAV1RegistrationDataHelper.Password);
            formCompletionHelper.Click(AcceptTermsAndCondition);
            formCompletionHelper.Click(ButtonRegister);
            return this;
        }

        public string FormInfoText()
        {
            pageInteractionHelper.WaitforURLToChange("registrationEmailSent");
            return pageInteractionHelper.GetText(ConfirmationText);
        }
    }
}
