using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    class AS_UserInvitedPage : BasePage
    {
        protected override string PageTitle => "User invited";
        private By InviteSomeoneElseLink => By.LinkText("Invite someone else");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public AS_UserInvitedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public AS_InviteUserPage ClickInviteSomeoneElseLink()
        {
            _formCompletionHelper.Click(InviteSomeoneElseLink);
            return new AS_InviteUserPage(_context);
        }
    }
}
