using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoggedInHomePage : EPAO_BasePage
    {
        protected override string PageTitle => ""; //There is NO Title on this page
        private readonly ScenarioContext _context;

        #region Locators
        private By RecordAGradeLink => By.Id("Record a grade");
        private By CompletedAssessmentsTopMenuLink => By.Id("Completed assessments");
        private By OrganisationDetailsTopMenuLink => By.LinkText("Organisation details");
        private By WithdrawFromAStandardLink => By.LinkText("Withdraw from a standard");
        private By WithdrawFromTheRegisterLink => By.LinkText("Withdraw from the register");
        private By ManageUsersLink => By.LinkText("Manage users");
        private By HomeTopMenuLink => By.Id("Home");
        private By SignedInUserNameText => By.CssSelector(".das-user-panel__content");
        private By SignOutLink => By.XPath("//a[@href='/Account/SignOut']");
        private By ApplyToAssessStandardLink => By.CssSelector("a[href='/ApplyToAssessStandard']");
        #endregion

        public AS_LoggedInHomePage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplyToAssessStandardPage ApplyToAssessStandard()
        {
            formCompletionHelper.Click(ApplyToAssessStandardLink);
            return new AS_ApplyToAssessStandardPage(_context);
        }

        public AS_RecordAGradePage ClickOnRecordAGrade()
        {
            formCompletionHelper.Click(RecordAGradeLink);
            return new AS_RecordAGradePage(_context);
        }

        public AS_CompletedAssessmentsPage ClickCompletedAssessmentsLink()
        {
            formCompletionHelper.Click(CompletedAssessmentsTopMenuLink);
            return new AS_CompletedAssessmentsPage(_context);
        }

        public void ClickOrganisationDetailsTopMenuLink()
        {
            formCompletionHelper.Click(OrganisationDetailsTopMenuLink);
        }

        public AS_UsersPage ClickManageUsersLink()
        {
            formCompletionHelper.Click(ManageUsersLink);
            return new AS_UsersPage(_context);
        }

        public AS_LoggedInHomePage ClickHomeTopMenuLink()
        {
            formCompletionHelper.Click(HomeTopMenuLink);
            return this;
        }

        public bool VerifySignedInUserName(string expectedText) => pageInteractionHelper.VerifyText(SignedInUserNameText, expectedText);

        public AS_SignedOutPage ClickSignOutLink()
        {
            formCompletionHelper.Click(SignOutLink);
            return new AS_SignedOutPage(_context);
        }
        public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromAStandardLink()
        {
            formCompletionHelper.Click(WithdrawFromAStandardLink);
            return new AS_WithdrawFromAStandardOrTheRegisterPage(_context);
        }

        public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromTheRegisterLink()
        {
            formCompletionHelper.Click(WithdrawFromTheRegisterLink);
            return new AS_WithdrawFromAStandardOrTheRegisterPage(_context);
        }
    }
}
