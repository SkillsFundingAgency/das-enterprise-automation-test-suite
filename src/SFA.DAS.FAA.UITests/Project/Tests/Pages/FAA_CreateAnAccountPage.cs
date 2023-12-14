using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_CreateAnAccountPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Create an account";

        #region Locators
        private static By FirstName => By.Id("Firstname");
        private static By LastName => By.Id("Lastname");
        private static By DOB_Day => By.Id("DateOfBirth_Day");
        private static By DOB_Month => By.Id("DateOfBirth_Month");
        private static By DOB_Year => By.Id("DateOfBirth_Year");
        private static By PostCode => By.Id("postcode-search");
        private static By PostCodeAutoSuggestResults => By.CssSelector(".ui-menu-item");
        private static By EmailId => By.Id("EmailAddress");
        private static By PhoneNumber => By.Id("PhoneNumber");
        private static By Password => By.Id("Password");
        private static By ConfirmPassword => By.Id("ConfirmPassword");
        private static By AcceptTermsAndConditions => By.CssSelector("input#HasAcceptedTermsAndConditions");
        private static By CreateAccountButton => By.Id("create-account-btn");
        private static By RegisteredEmailErrorMessage => By.ClassName("error-summary-list");

        #endregion

        public FAA_ActivateYourAccountPage CreateAccount()
        {
            CreateAccount(faaDataHelper.EmailId);

            pageInteractionHelper.WaitforURLToChange("activation");

            return new FAA_ActivateYourAccountPage(context);
        }

        public void SelectAddress()
        {
            formCompletionHelper.EnterText(PostCode, faaDataHelper.PostCode);

            pageInteractionHelper.WaitUntilAnyElements(PostCodeAutoSuggestResults);

            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(PostCodeAutoSuggestResults)));
        }

        public void CreateAccountWithRegisteredEmail()
        {
            CreateAccount(faaConfig.FAAUserName);

            CheckTheValidationMessagesForAlreadyRegisteredEmail();
        }

        private void CreateAccount(string email)
        {
            formCompletionHelper.EnterText(FirstName, faaDataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, faaDataHelper.LastName);
            formCompletionHelper.EnterText(DOB_Day, faaDataHelper.DOB_Day);
            formCompletionHelper.EnterText(DOB_Month, faaDataHelper.DOB_Month);
            formCompletionHelper.EnterText(DOB_Year, faaDataHelper.DOB_Year);
            SelectAddress();
            formCompletionHelper.EnterText(EmailId, email);
            formCompletionHelper.EnterText(PhoneNumber, faaDataHelper.PhoneNumber);
            formCompletionHelper.EnterText(Password, faaDataHelper.Password);
            formCompletionHelper.EnterText(ConfirmPassword, faaDataHelper.Password);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            formCompletionHelper.Click(CreateAccountButton);
        }

        public void CheckTheValidationMessagesForAlreadyRegisteredEmail() => pageInteractionHelper.VerifyText(RegisteredEmailErrorMessage, faaDataHelper.CreateAccountWithRegisteredEmailErrorMessage);
    }
}