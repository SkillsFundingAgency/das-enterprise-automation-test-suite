using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class UnlockAccountPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//*[@class=\"grid-row\"]//h1")] private IWebElement _notificationHeader;
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"grid-row\"]//p")] private IWebElement _notificationMessage;
        [FindsBy(How = How.Id, Using = "Email")] private IWebElement _emailInput;
        [FindsBy(How = How.Id, Using = "UnlockCode")] private IWebElement _unlockCodeInput;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _unlockAccountButton;

        public UnlockAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public string Email
        {
            get { return _emailInput.GetAttribute("value"); }
            set
            {
                _emailInput.Clear();
                _formCompletionHelper.EnterText(_emailInput, value ?? "");
            }
        }

        public string UnlockCode
        {
            get { return _unlockCodeInput.GetAttribute("value"); }
            set
            {
                _unlockCodeInput.Clear();
                _formCompletionHelper.EnterText(_unlockCodeInput, value ?? "");
            }
        }

        public string GetNotificationHeader()
        {
            return _notificationHeader.Text;
        }

        public string GetNotificationMessage()
        {
            return _notificationMessage.Text;
        }

        public SignInPage UnlockAccount()
        {
            _unlockAccountButton.Click();
            return new SignInPage(_context);
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