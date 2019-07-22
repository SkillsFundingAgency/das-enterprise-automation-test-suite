using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class InvitationsPage: BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _acceptButton = By.Id("invitationId");

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