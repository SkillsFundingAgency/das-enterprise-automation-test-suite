using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class YourOrganizationsBasePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _addNewOrganizationButton = By.Id("addNewOrg");
        private readonly By _removeAnOrgLink = By.XPath("//a[contains(text(), 'Remove an organisation from your account')]");
        private readonly By _orgRemovedMessage = By.XPath("//h1");

        private readonly IWebDriver _webDriver;

        public YourOrganizationsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal string[] GetOrganizationNames()
        {
            var elements = _webDriver.FindElements(By.XPath(".//table/tbody/tr/td"));
            return elements.Select(element => element.Text).ToArray();
        }

        internal EnterOrganizationNamePage AddNewOrganization()
        {
            _formCompletionHelper.ClickElement(_addNewOrganizationButton);
            return new EnterOrganizationNamePage(_context);
        }

        internal string GetNotification()
        {
            var notificationElement =
                _webDriver.FindElement(By.ClassName("success-summary"));
            return notificationElement.Text;
        }

        internal string[] GetErrors()
        {
            return _webDriver
               .FindElements(By.CssSelector(".error-summary-list li"))
               .Select((element) => element.Text)
               .ToArray();
        }

        internal RemoveOrganizationPage ClickRemoveOrgLink()
        {
            _formCompletionHelper.ClickElement(_removeAnOrgLink);
            return new RemoveOrganizationPage(_context);
        }

        public string GetOrgRemovedHeaderMessage()
        {
            return _pageInteractionHelper.GetText(_orgRemovedMessage);
        }
    }
}