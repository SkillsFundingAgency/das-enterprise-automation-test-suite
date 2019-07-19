using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class YourTeamPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "heading-xlarge")]
        private IWebElement _pageHeader;
        [FindsBy(How = How.Id, Using = "addNewUser")]
        private IWebElement _inviteMemterButton;
        [FindsBy(How = How.CssSelector, Using = ".success-summary p")]
        private IWebElement _notificationMessage;

        public YourTeamPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.GetText(_pageHeader) == "Your team";
        }

        internal CreateInvitationPage OpenInviteMemberPage()
        {
            formCompletionHelper.ClickElement(_inviteMemterButton);
            return new CreateInvitationPage(WebBrowserDriver);
        }

        internal string GetNotification()
        {
            return _notificationMessage.Text;
        }

        internal string[] GetMembersEmails()
        {
            var elements =
                WebBrowserDriver.FindElements(By.ClassName("responsive-detail"));
            return elements
                .Select((element) => element.Text)
                .ToArray();
        }

        internal ViewMemberPage ViewLastMember()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//a[contains (text(), \'View\')]"));
            formCompletionHelper.ClickElement(elements.Last());
            return new ViewMemberPage(WebBrowserDriver);
        }
    }
}