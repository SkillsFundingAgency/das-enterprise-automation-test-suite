using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class RemoveOrganizationPage : BasePage
    {
        private By _secondOrgInTheList = By.XPath("(//a[contains (text(), 'Remove ')])[2]");
        public RemoveOrganizationPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public string[] GetOrganizationsInfo()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//tr/td[2]"));
            return elements
                .Select((element) => element.Text)
                .ToArray();
        }

        public RemoveOrganizationConfirmPage ClickSecondOrgInTheList()
        {
            formCompletionHelper.ClickElement(_secondOrgInTheList);
            return new RemoveOrganizationConfirmPage(WebBrowserDriver);
        }
    }
}
