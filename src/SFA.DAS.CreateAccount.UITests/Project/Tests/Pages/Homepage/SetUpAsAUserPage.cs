using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class SetUpAsAUserPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.ClassName, Using = "error-summary")] private IWebElement ErrorBox { get; set; }
        [FindsBy(How = How.ClassName, Using = "heading-xlarge")] private IWebElement PageHeader { get; set; }
        [FindsBy(How = How.Id, Using = "FirstName")] private IWebElement FirstName { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Enter first name\')]")] private IWebElement FirstNameErrorInBox { get; set; }
        [FindsBy(How = How.Id, Using = "LastName")] private IWebElement LastName { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Enter last name\')]")] private IWebElement LastNameErrorInBox { get; set; }
        [FindsBy(How = How.Id, Using = "Email")] private IWebElement Email { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Enter a valid email address\')]")] private IWebElement EmailErrorInBox { get; set; }
        [FindsBy(How = How.Id, Using = "Password")] private IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Enter password\')]")] private IWebElement PasswordErrorInBox { get; set; }
        [FindsBy(How = How.XPath, Using = ".//span[contains (text(), \'Password requires\')]")] private IWebElement PasswordValidationErrorField { get; set; }
        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private IWebElement PasswordConfirm { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Re-type password\')]")] private IWebElement PasswordCnfErrorInBox { get; set; }
        [FindsBy(How = How.Id, Using = "button-register")] private IWebElement SetMeUp { get; set; }
        private By _signInLink = By.XPath("//a[contains(text(), 'sign in')]");
        private By _termsAndConditionsLink = By.XPath("//a[contains(text(),'terms and conditions')]");

        public SetUpAsAUserPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            IsPagePresented();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(PageHeader) == "Set up as a user";
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
            LastName.SendKeys(lastName);
            Email.SendKeys(email);
            Password.SendKeys(passWord);
            PasswordConfirm.SendKeys(passWord);
        }

        private void SubmitForm()
        {
            _formCompletionHelper.ClickElement(SetMeUp);
        }

        internal bool IsTheErrorBoxDisplayed()
        {
            return ErrorBox.Displayed;
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
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary-list\"]//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}