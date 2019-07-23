using System;
using System.Linq;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class SetUpAsAUserPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ErrorBox => By.ClassName("error-summary");

        private By FirstNameErrorInBox => By.XPath(".//a[contains (text(), \'Enter first name\')]");

        private By LastName => By.Id("LastName");

        private By LastNameErrorInBox => By.XPath(".//a[contains (text(), \'Enter last name\')]");

        private By Email => By.Id("Email");
        private By EmailErrorInBox => By.XPath(".//a[contains (text(), \'Enter a valid email address\')]");

        private By Password => By.Id("Password");

        private By PasswordErrorInBox => By.XPath(".//a[contains (text(), \'Enter password\')]");

        private By PasswordValidationErrorField => By.XPath(".//span[contains (text(), \'Password requires\')]");

        private By PasswordConfirm => By.Id("ConfirmPassword");
        private By PasswordCnfErrorInBox => By.XPath(".//a[contains (text(), \'Re-type password\')]");

        private By SetMeUp => By.Id("button-register");

        private By _signInLink => By.XPath("//a[contains(text(), 'sign in')]");

        private By _termsAndConditionsLink => By.XPath("//a[contains(text(),'terms and conditions')]");

        private readonly IWebDriver _webdriver;


        protected override By PageHeader => By.ClassName("heading-xlarge");

        private By FirstName => By.Id("FirstName");

        public SetUpAsAUserPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented("Set up as a user");
        }

        internal bool IsSignInLinkPresent()
        {
            return _pageInteractionHelper.IsElementDisplayed(_signInLink);
        }

        internal void ClickOnSignInLink()
        {
            _formCompletionHelper.ClickElement(_signInLink);
        }

        internal bool IsTermsAndConditionsLinkPresent()
        {
            return _pageInteractionHelper.IsElementDisplayed(_termsAndConditionsLink);
        }

        internal void ClickOnTermsAndConditionsLink()
        {
            _formCompletionHelper.ClickElement(_termsAndConditionsLink);
        }

        internal SetUpAsAUserPage SubmitInvalidForm(string firstName, string lastName, string email, string passWord)
        {
            CompleteForm(firstName, lastName, email, passWord);
            SubmitForm();
            return this;
        }

        internal ConfirmYourIdentityPage SubmitValidForm(string firstName, string lastName, string email, string passWord, string ReEnterPassword)
        {
            CompleteForm(firstName, lastName, email, passWord);
            SubmitForm();
            return new ConfirmYourIdentityPage(_context);
        }

        internal SetUpAsAUserPage SubmitIncompleteForm()
        {
            SubmitForm();
            return this;
        }

        private void CompleteForm(string firstName, string lastName, string email, string passWord)
        {
            _formCompletionHelper.EnterText(FirstName, firstName);
            _formCompletionHelper.EnterText(LastName, lastName);
            _formCompletionHelper.EnterText(Email, email);
            _formCompletionHelper.EnterText(Password, passWord);
            _formCompletionHelper.EnterText(PasswordConfirm, passWord);
        }

        private void SubmitForm()
        {
            _formCompletionHelper.ClickElement(SetMeUp);
        }

        internal bool IsTheErrorBoxDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(ErrorBox);
        }

        internal string GetFirstNameRequiredInBox()
        {
            return _pageInteractionHelper.GetText(FirstNameErrorInBox);
        }

        internal string GetLastNameRequiredInBox()
        {
            return _pageInteractionHelper.GetText(LastNameErrorInBox);
        }

        internal string GetEmailRequiredInBox()
        {
            return _pageInteractionHelper.GetText(EmailErrorInBox);
        }

        internal string GetPasswordRequiredInBox()
        {
            return _pageInteractionHelper.GetText(PasswordErrorInBox);
        }

        internal string GetPasswordValidationMessage()
        {
            return _pageInteractionHelper.GetText(PasswordValidationErrorField);
        }

        internal string GetPasswordRetryRequiredInBox()
        {
            return _pageInteractionHelper.GetText(PasswordCnfErrorInBox);
        }

        internal string[] GetErrors()
        {
            return _webdriver
                .FindElements(By.XPath(".//*[@class=\"error-summary-list\"]//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}