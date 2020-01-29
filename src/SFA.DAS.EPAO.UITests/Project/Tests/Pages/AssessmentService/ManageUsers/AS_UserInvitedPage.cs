using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    class AS_UserInvitedPage : EPAO_BasePage
    {
        protected override string PageTitle => "User invited";
        private readonly ScenarioContext _context;

        private By InviteSomeoneElseLink => By.LinkText("Invite someone else");

        public AS_UserInvitedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_InviteUserPage ClickInviteSomeoneElseLink()
        {
            formCompletionHelper.Click(InviteSomeoneElseLink);
            return new AS_InviteUserPage(_context);
        }
    }
}
