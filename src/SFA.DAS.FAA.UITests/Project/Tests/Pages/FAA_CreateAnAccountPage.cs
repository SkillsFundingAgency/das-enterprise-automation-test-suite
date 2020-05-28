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
            _formCompletionHelper.EnterText(FirstName, _faadataHelper.FirstName);
            _formCompletionHelper.EnterText(LastName, _faadataHelper.LastName);
            _formCompletionHelper.EnterText(DOB_Day, _faadataHelper.DOB_Day);
            _formCompletionHelper.EnterText(DOB_Month, _faadataHelper.DOB_Month);
            _formCompletionHelper.EnterText(DOB_Year, _faadataHelper.DOB_Year);
            SelectAddress();
            _formCompletionHelper.EnterText(EmailId, _faadataHelper.EmailId);
            _formCompletionHelper.EnterText(PhoneNumber, _faadataHelper.PhoneNumber);
            _formCompletionHelper.EnterText(Password, _faadataHelper.Password);
            _formCompletionHelper.EnterText(ConfirmPassword, _faadataHelper.Password);
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            _formCompletionHelper.Click(CreateAccountButton);
            _pageInteractionHelper.WaitforURLToChange("activation");
            return new FAA_ActivateYourAccountPage(_context);
        }

        public void SelectAddress()
        {
            _formCompletionHelper.EnterText(PostCode, _faadataHelper.PostCode);
            _pageInteractionHelper.WaitUntilAnyElements(PostCodeAutoSuggestResults);
            _formCompletionHelper.ClickElement(() => _faadataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(PostCodeAutoSuggestResults)));
        }

        public void SubmitAccountCreationDetailsWithRegisteredEmail()
        {
            _formCompletionHelper.EnterText(FirstName, _faadataHelper.FirstName);
            _formCompletionHelper.EnterText(LastName, _faadataHelper.LastName);
            _formCompletionHelper.EnterText(DOB_Day, _faadataHelper.DOB_Day);
            _formCompletionHelper.EnterText(DOB_Month, _faadataHelper.DOB_Month);
            _formCompletionHelper.EnterText(DOB_Year, _faadataHelper.DOB_Year);
            SelectAddress();
            _formCompletionHelper.EnterText(EmailId, _config.FAAUserName);
            _formCompletionHelper.EnterText(PhoneNumber, _faadataHelper.PhoneNumber);
            _formCompletionHelper.EnterText(Password, _faadataHelper.Password);
            _formCompletionHelper.EnterText(ConfirmPassword, _faadataHelper.Password);
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            _formCompletionHelper.Click(CreateAccountButton);
            CheckTheValidationMessagesForAlreadyRegisteredEmail();
        }

        public void CheckTheValidationMessagesForAlreadyRegisteredEmail()
        {
            _pageInteractionHelper.VerifyText(RegisteredEmailErrorMessage, _faadataHelper.CreateAccountWithRegisteredEmailErrorMessage);            
        }
    }
}