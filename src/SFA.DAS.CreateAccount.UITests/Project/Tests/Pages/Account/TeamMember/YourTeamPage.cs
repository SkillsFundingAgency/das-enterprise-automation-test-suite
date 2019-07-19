using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class YourTeamPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.ClassName, Using = "heading-xlarge")]
        private IWebElement _pageHeader;
        [FindsBy(How = How.Id, Using = "addNewUser")]
        private IWebElement _inviteMemterButton;
        [FindsBy(How = How.CssSelector, Using = ".success-summary p")]
        private IWebElement _notificationMessage;

        public YourTeamPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(_pageHeader) == "Your team";
        }

        internal CreateInvitationPage OpenInviteMemberPage()
        {
            _formCompletionHelper.ClickElement(_inviteMemterButton);
            return new CreateInvitationPage(_context);
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
            _formCompletionHelper.ClickElement(elements.Last());
            return new ViewMemberPage(_context);
        }
    }
}