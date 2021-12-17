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
        private By ApprovedStandardsAndVersions => By.CssSelector("a[href='/OrganisationStandards']");
        #endregion

        public AS_LoggedInHomePage(ScenarioContext context) : base(context) { }

        public AS_ApplyToAssessStandardPage ApplyToAssessStandard()
        {
            formCompletionHelper.Click(ApplyToAssessStandardLink);
            return new AS_ApplyToAssessStandardPage(context);
        }

        public ApprovedStandardsAndVersionsLandingPage ApprovedStandardAndVersions()
        {
            formCompletionHelper.Click(ApprovedStandardsAndVersions);
            return new ApprovedStandardsAndVersionsLandingPage(context);
        }

        public AS_RecordAGradePage GoToRecordAGradePage()
        {
            formCompletionHelper.Click(RecordAGradeLink);
            return new AS_RecordAGradePage(context);
        }

        public AS_CompletedAssessmentsPage ClickCompletedAssessmentsLink()
        {
            formCompletionHelper.Click(CompletedAssessmentsTopMenuLink);
            return new AS_CompletedAssessmentsPage(context);
        }

        public void ClickOrganisationDetailsTopMenuLink()
        {
            formCompletionHelper.Click(OrganisationDetailsTopMenuLink);
        }

        public AS_UsersPage ClickManageUsersLink()
        {
            formCompletionHelper.Click(ManageUsersLink);
            return new AS_UsersPage(context);
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
            return new AS_SignedOutPage(context);
        }
        public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromAStandardLink()
        {
            formCompletionHelper.Click(WithdrawFromAStandardLink);
            return new AS_WithdrawFromAStandardOrTheRegisterPage(context);
        }

        public AS_WithdrawFromAStandardOrTheRegisterPage ClickWithdrawFromTheRegisterLink()
        {
            formCompletionHelper.Click(WithdrawFromTheRegisterLink);
            return new AS_WithdrawFromAStandardOrTheRegisterPage(context);
        }
    }
}
