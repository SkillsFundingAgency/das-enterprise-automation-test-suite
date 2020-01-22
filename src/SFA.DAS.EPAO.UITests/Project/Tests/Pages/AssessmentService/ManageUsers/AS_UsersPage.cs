using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_UsersPage : EPAO_BasePage
    {
        protected override string PageTitle => "Users";
        private readonly ScenarioContext _context;

        #region Locators
        private By ManageUserNameLink => By.LinkText("Mr Preprod Epao0007");
        private By PermissionsEditUserLink => By.LinkText("Liz Kemp");
        private By InviteNewUSerButton => By.LinkText("Invite new user");
        #endregion

        public AS_UsersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_UserDetailsPage ClickManageUserNameLink()
        {
            formCompletionHelper.Click(ManageUserNameLink);
            return new AS_UserDetailsPage(_context);
        }

        public AS_UserDetailsPage ClickPermissionsEditUserLink()
        {
            formCompletionHelper.Click(PermissionsEditUserLink);
            return new AS_UserDetailsPage(_context);
        }

        public AS_InviteUserPage ClickInviteNewUserButton()
        {
            formCompletionHelper.Click(InviteNewUSerButton);
            return new AS_InviteUserPage(_context);
        }

        public AS_UserDetailsPage ClickOnNewlyAddedUserLink(string userEmail)
        {
            formCompletionHelper.Click(By.XPath($"//span[text()='{userEmail}']/..//a"));
            return new AS_UserDetailsPage(_context);
        }
    }
}
