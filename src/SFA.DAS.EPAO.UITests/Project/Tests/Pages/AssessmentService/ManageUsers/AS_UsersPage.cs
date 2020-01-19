using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_UsersPage : BasePage
    {
        protected override string PageTitle => "Users";

        #region Locators
        private By ManageUserNameLink => By.LinkText("Mr Preprod Epao0007");
        private By PermissionsEditUserLink => By.LinkText("Liz Kemp");
        private By InviteNewUSerButton => By.LinkText("Invite new user");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public AS_UsersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_UserDetailsPage ClickManageUserNameLink()
        {
            _formCompletionHelper.Click(ManageUserNameLink);
            return new AS_UserDetailsPage(_context);
        }

        public AS_UserDetailsPage ClickPermissionsEditUserLink()
        {
            _formCompletionHelper.Click(PermissionsEditUserLink);
            return new AS_UserDetailsPage(_context);
        }

        public AS_InviteUserPage ClickInviteNewUserButton()
        {
            _formCompletionHelper.Click(InviteNewUSerButton);
            return new AS_InviteUserPage(_context);
        }

        public AS_UserDetailsPage ClickOnNewlyAddedUserLink(string userEmail)
        {
            _formCompletionHelper.Click(By.XPath($"//span[text()='{userEmail}']/..//a"));
            return new AS_UserDetailsPage(_context);
        }
    }
}
