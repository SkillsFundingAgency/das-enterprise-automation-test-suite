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
    }
}
