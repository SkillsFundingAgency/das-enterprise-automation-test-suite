using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class InvitationsPage: BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "invitationId")] private IWebElement _acceptButton;

        public InvitationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        
        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_acceptButton);
        }

        public void AcceptTheLastInvitation()
        {
            _formCompletionHelper.ClickElement(_acceptButton);
        }
    }
}