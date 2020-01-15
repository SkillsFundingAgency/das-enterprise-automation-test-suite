using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

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
        private By CompletedAssessmentsLink  => By.Id("Completed assessments");
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
            _formCompletionHelper.Click(CompletedAssessmentsLink);
            return new AS_CompletedAssessmentsPage(_context);
        }
    }
}
