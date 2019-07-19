using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class YourAccountsPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "heading-xlarge")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'View Invitations\')]")] private IWebElement _invitationsButton;

        public YourAccountsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _pageHeader) == "Your accounts";
        }

        internal EmployerAccountHomepage OpenAccount()
        {
            var openButtons = WebBrowserDriver
                .FindElements(By.XPath(".//a[contains (text(), \'Open\')]"));
            openButtons.First().Click();
            return new EmployerAccountHomepage(WebBrowserDriver);
        }

        internal InvitationsPage OpenInvitationsPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _invitationsButton);
            return new InvitationsPage(WebBrowserDriver);
        }
    }
}