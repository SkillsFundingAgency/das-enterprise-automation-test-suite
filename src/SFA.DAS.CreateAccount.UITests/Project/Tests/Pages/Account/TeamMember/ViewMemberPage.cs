using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.TeamMember
{
    public class ViewMemberPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "resend_invitation")] private IWebElement _resendButton;
        [FindsBy(How = How.Id, Using = "cancel_invitation")] private IWebElement _confirmCancellation;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Cancel Invitation\')]")] private IWebElement _cancelInvitation;
        [FindsBy(How = How.ClassName, Using = "button-link")] private IWebElement _forbidCancellation;
        [FindsBy(How = How.Id, Using = "delete_user")] private IWebElement _removeMemberButton;
        [FindsBy(How = How.Id, Using = "remove_team_member")] private IWebElement _confirmTheMemberRemovalButton;

        public ViewMemberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal void ResendInvitation()
        {
            _formCompletionHelper.ClickElement(_resendButton);
        }

        internal ViewMemberPage CancelInvitation()
        {
            _formCompletionHelper.ClickElement(_cancelInvitation);
            return this;
        }

        internal void ConfirmCancellation()
        {
            _formCompletionHelper.ClickElement(_confirmCancellation);
        }

        internal void ForbidCancellation()
        {
            _formCompletionHelper.ClickElement(_forbidCancellation);
        }

        internal YourTeamPage RemoveMember()
        {
            _formCompletionHelper.ClickElement(_removeMemberButton);
            _formCompletionHelper.ClickElement(_confirmTheMemberRemovalButton);
            return new YourTeamPage(_context);
        }
    }
}