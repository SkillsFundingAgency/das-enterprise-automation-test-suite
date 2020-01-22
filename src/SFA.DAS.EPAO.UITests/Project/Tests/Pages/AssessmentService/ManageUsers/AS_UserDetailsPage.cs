using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_UserDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "User details";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        private readonly ScenarioContext _context;

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

        public AS_UserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_EditUserPermissionsPage ClickEditUserPermissionLink()
        {
            formCompletionHelper.Click(EditUserPermissionLink);
            return new AS_EditUserPermissionsPage(_context);
        }

        public bool IsViewDashboardPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ViewDashboardPermission);

        public bool IsChangeOrganisationDetailsPersmissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeOrganisationDetailsPersmission);

        public bool IsPipelinePermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(PipelinePermission);

        public bool IsCompletedAssessmentsPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(CompletedAssessmentsPermission);

        public bool IsApplyForAStandardPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ApplyForAStandardPermission);

        public bool IsManageUsersPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ManageUsersPermission);

        public bool IsRecordGradesPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(RecordGradesPermission);

        public AS_RemoveUserPage ClicRemoveThisUserLinkInUserDetailPage()
        {
            formCompletionHelper.Click(RemoveThisUserLink);
            return new AS_RemoveUserPage(_context);
        }
    }
}
