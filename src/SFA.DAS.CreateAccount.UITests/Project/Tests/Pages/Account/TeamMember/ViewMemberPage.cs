using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class ViewMemberPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "resend_invitation")] private IWebElement _resendButton;
        [FindsBy(How = How.Id, Using = "cancel_invitation")] private IWebElement _confirmCancellation;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Cancel Invitation\')]")] private IWebElement _cancelInvitation;
        [FindsBy(How = How.ClassName, Using = "button-link")] private IWebElement _forbidCancellation;
        [FindsBy(How = How.Id, Using = "delete_user")] private IWebElement _removeMemberButton;
        [FindsBy(How = How.Id, Using = "remove_team_member")] private IWebElement _confirmTheMemberRemovalButton;

        public ViewMemberPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal void ResendInvitation()
        {
            formCompletionHelper.ClickElement(_resendButton);
        }

        internal ViewMemberPage CancelInvitation()
        {
            formCompletionHelper.ClickElement(_cancelInvitation);
            return this;
        }

        internal void ConfirmCancellation()
        {
            formCompletionHelper.ClickElement(_confirmCancellation);
        }

        internal void ForbidCancellation()
        {
            formCompletionHelper.ClickElement(_forbidCancellation);
        }

        internal YourTeamPage RemoveMember()
        {
            formCompletionHelper.ClickElement(_removeMemberButton);
            formCompletionHelper.ClickElement(_confirmTheMemberRemovalButton);
            return new YourTeamPage(WebBrowserDriver);
        }
    }
}