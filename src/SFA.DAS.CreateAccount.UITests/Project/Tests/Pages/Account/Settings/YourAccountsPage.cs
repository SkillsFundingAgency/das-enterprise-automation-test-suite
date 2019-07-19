using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class YourAccountsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.ClassName, Using = "heading-xlarge")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'View Invitations\')]")] private IWebElement _invitationsButton;

        public YourAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(_pageHeader) == "Your accounts";
        }

        internal EmployerAccountHomepage OpenAccount()
        {
            var openButtons = WebBrowserDriver
                .FindElements(By.XPath(".//a[contains (text(), \'Open\')]"));
            openButtons.First().Click();
            return new EmployerAccountHomepage(_context);
        }

        internal InvitationsPage OpenInvitationsPage()
        {
            _formCompletionHelper.ClickElement(_invitationsButton);
            return new InvitationsPage(_context);
        }
    }
}