using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoggedInHomePage : BasePage
    {
        protected override string PageTitle => ""; //There is NO Title on this page

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;

        #endregion

        #region Locators
        private By RecordAGradeLink => By.Id("Record a grade");
        private By CompletedAssessmentsTopMenuLink => By.Id("Completed assessments");
        private By OrganisationDetailsTopMenuLink => By.LinkText("Organisation details");
        private By ManageUsersLink => By.LinkText("Manage users");
        #endregion

        public AS_LoggedInHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage(RecordAGradeLink);
        }

        public AS_RecordAGradePage ClickOnRecordAGrade()
        {
            _formCompletionHelper.Click(RecordAGradeLink);
            return new AS_RecordAGradePage(_context);
        }

        public AS_CompletedAssessmentsPage ClickCompletedAssessmentsLink()
        {
            _formCompletionHelper.Click(CompletedAssessmentsTopMenuLink);
            return new AS_CompletedAssessmentsPage(_context);
        }

        public void ClickOrganisationDetailsTopMenuLink()
        {
            _formCompletionHelper.Click(OrganisationDetailsTopMenuLink);
        }

        public AS_UsersPage ClickManageUsersLink()
        {
            _formCompletionHelper.Click(ManageUsersLink);
            return new AS_UsersPage(_context);
        }
    }
}
