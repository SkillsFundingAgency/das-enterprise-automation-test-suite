using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_UserDetailsPage : BasePage
    {
        protected override string PageTitle => "User details";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Locators
        private By EditUserPermissionLink => By.LinkText("Edit user permissions");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public AS_UserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_EditUserPermissionsPage ClickEditUserPermissionLink()
        {
            _formCompletionHelper.Click(EditUserPermissionLink);
            return new AS_EditUserPermissionsPage(_context);
        }
    }
}
