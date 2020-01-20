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
        private By ViewDashboardPermission => By.XPath("//li[contains(text(),'View dashboard')]");
        private By ChangeOrganisationDetailsPersmission => By.XPath("//li[contains(text(),'Change organisation details')]");
        private By PipelinePermission => By.XPath("//li[contains(text(),'Pipeline')]");
        private By CompletedAssessmentsPermission => By.XPath("//li[contains(text(),'Completed assessments')]");
        private By ApplyForAStandardPermission => By.XPath("//li[contains(text(),'Apply for a Standard')]");
        private By ManageUsersPermission => By.XPath("//li[contains(text(),'Manage users')]");
        private By RecordGradesPermission => By.XPath("//li[contains(text(),'Record grades and issue certificates')]");
        private By RemoveThisUserLink => By.LinkText("Remove this user");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public AS_UserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public AS_EditUserPermissionsPage ClickEditUserPermissionLink()
        {
            _formCompletionHelper.Click(EditUserPermissionLink);
            return new AS_EditUserPermissionsPage(_context);
        }

        public bool IsViewDashboardPermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(ViewDashboardPermission);

        public bool IsChangeOrganisationDetailsPersmissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(ChangeOrganisationDetailsPersmission);

        public bool IsPipelinePermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(PipelinePermission);

        public bool IsCompletedAssessmentsPermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(CompletedAssessmentsPermission);

        public bool IsApplyForAStandardPermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(ApplyForAStandardPermission);

        public bool IsManageUsersPermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(ManageUsersPermission);

        public bool IsRecordGradesPermissionDisplayed() => _pageInteractionHelper.IsElementDisplayed(RecordGradesPermission);

        public AS_RemoveUserPage ClicRemoveThisUserLinkInUserDetailPage()
        {
            _formCompletionHelper.Click(RemoveThisUserLink);
            return new AS_RemoveUserPage(_context);
        }
    }
}
