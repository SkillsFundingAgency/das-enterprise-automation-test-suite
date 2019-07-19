using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ChangeEmailPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "NewEmailAddress")] private IWebElement NewEmailInput;
        [FindsBy(How = How.Id, Using = "ConfirmEmailAddress")] private IWebElement ConfirmEmailInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement ContinueButton;
        private const string PageTitle = "Change your email address";

        public ChangeEmailPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal ChangeEmailPage InputEmail(string email)
        {
            _formCompletionHelper.EnterText(NewEmailInput, email);
            return this;
        }

        internal ChangeEmailPage ConfirmEmail(string email)
        {
            _formCompletionHelper.EnterText(ConfirmEmailInput, email);
            return this;
        }

        internal ConfirmUpdatedEmailPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmUpdatedEmailPage(_context);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//ul//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}