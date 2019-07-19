using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class YourOrganizationsBasePage : BasePage
    {
        private By _addNewOrganizationButton = By.Id("addNewOrg");
        private By _removeAnOrgLink = By.XPath("//a[contains(text(), 'Remove an organisation from your account')]");
        private By _orgRemovedMessage = By.XPath("//h1");

        public YourOrganizationsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal string[] GetOrganizationNames()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//table/tbody/tr/td"));
            return elements.Select(element => element.Text).ToArray();
        }

        internal EnterOrganizationNamePage AddNewOrganization()
        {
            _formCompletionHelper.ClickElement(_addNewOrganizationButton);
            return new EnterOrganizationNamePage(WebBrowserDriver);
        }

        internal string GetNotification()
        {
            var notificationElement =
                WebBrowserDriver.FindElement(By.ClassName("success-summary"));
            return notificationElement.Text;
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
               .FindElements(By.CssSelector(".error-summary-list li"))
               .Select((element) => element.Text)
               .ToArray();
        }

        internal RemoveOrganizationPage ClickRemoveOrgLink()
        {
            _formCompletionHelper.ClickElement(_removeAnOrgLink);
            return new RemoveOrganizationPage(WebBrowserDriver);
        }

        public string GetOrgRemovedHeaderMessage()
        {
            return pageInteractionHelper.GetText(_orgRemovedMessage);
        }
    }
}