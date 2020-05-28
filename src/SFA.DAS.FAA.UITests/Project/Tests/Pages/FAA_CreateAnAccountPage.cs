using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_CreateAnAccountPage : FAABasePage
    {
        protected override string PageTitle => "Create an account";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By FirstName => By.Id("Firstname");
        private By LastName => By.Id("Lastname");
        private By DOB_Day => By.Id("DateOfBirth_Day");
        private By DOB_Month => By.Id("DateOfBirth_Month");
        private By DOB_Year => By.Id("DateOfBirth_Year");
        private By PostCode => By.Id("postcode-search");
        private By PostCodeAutoSuggestResults => By.CssSelector(".ui-menu-item");
        private By EmailId => By.Id("EmailAddress");
        private By PhoneNumber => By.Id("PhoneNumber");
        private By Password => By.Id("Password");
        private By ConfirmPassword => By.Id("ConfirmPassword");
        private By AcceptTermsAndConditions => By.CssSelector("input#HasAcceptedTermsAndConditions");
        private By CreateAccountButton => By.Id("create-account-btn");
        private By RegisteredEmailErrorMessage => By.ClassName("error-summary-list");


        #endregion

        public FAA_CreateAnAccountPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_ActivateYourAccountPage SubmitAccountCreationDetails()
        {
            formCompletionHelper.EnterText(FirstName, faadataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, faadataHelper.LastName);
            formCompletionHelper.EnterText(DOB_Day, faadataHelper.DOB_Day);
            formCompletionHelper.EnterText(DOB_Month, faadataHelper.DOB_Month);
            formCompletionHelper.EnterText(DOB_Year, faadataHelper.DOB_Year);
            SelectAddress();
            formCompletionHelper.EnterText(EmailId, faadataHelper.EmailId);
            formCompletionHelper.EnterText(PhoneNumber, faadataHelper.PhoneNumber);
            formCompletionHelper.EnterText(Password, faadataHelper.Password);
            formCompletionHelper.EnterText(ConfirmPassword, faadataHelper.Password);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            formCompletionHelper.Click(CreateAccountButton);
            pageInteractionHelper.WaitforURLToChange("activation");
            return new FAA_ActivateYourAccountPage(_context);
        }

        public void SelectAddress()
        {
            formCompletionHelper.EnterText(PostCode, faadataHelper.PostCode);
            pageInteractionHelper.WaitUntilAnyElements(PostCodeAutoSuggestResults);
            formCompletionHelper.ClickElement(() => faadataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(PostCodeAutoSuggestResults)));
        }

        public void SubmitAccountCreationDetailsWithRegisteredEmail()
        {
            formCompletionHelper.EnterText(FirstName, faadataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, faadataHelper.LastName);
            formCompletionHelper.EnterText(DOB_Day, faadataHelper.DOB_Day);
            formCompletionHelper.EnterText(DOB_Month, faadataHelper.DOB_Month);
            formCompletionHelper.EnterText(DOB_Year, faadataHelper.DOB_Year);
            SelectAddress();
            formCompletionHelper.EnterText(EmailId, faaconfig.FAAUserName);
            formCompletionHelper.EnterText(PhoneNumber, faadataHelper.PhoneNumber);
            formCompletionHelper.EnterText(Password, faadataHelper.Password);
            formCompletionHelper.EnterText(ConfirmPassword, faadataHelper.Password);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            formCompletionHelper.Click(CreateAccountButton);
            CheckTheValidationMessagesForAlreadyRegisteredEmail();
        }

        public void CheckTheValidationMessagesForAlreadyRegisteredEmail()
        {
            pageInteractionHelper.VerifyText(RegisteredEmailErrorMessage, faadataHelper.CreateAccountWithRegisteredEmailErrorMessage);            
        }
    }
}