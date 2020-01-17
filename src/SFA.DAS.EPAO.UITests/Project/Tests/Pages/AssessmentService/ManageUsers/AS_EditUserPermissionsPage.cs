using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_EditUserPermissionsPage : BasePage
    {
        protected override string PageTitle => "Edit user permissions";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Locators
        private By SaveButton => By.LinkText("Edit user permissions");
        private By ChangeOrganisationDetailsCheckBox => By.Id("PrivilegeViewModels[0].Selected");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        public AS_EditUserPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_EditUserPermissionsPage UnSelectChangeOrganisationDetailsCheckBox()
        {
            _formCompletionHelper.UnSelectCheckbox(ChangeOrganisationDetailsCheckBox);
            return this;
        }

        public AS_UserDetailsPage ClickSaveButton()
        {
            Continue();
            return new AS_UserDetailsPage(_context);
        }
    }
}
