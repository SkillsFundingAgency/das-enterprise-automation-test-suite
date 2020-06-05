using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AssessmentRecordedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Assessment recorded";
        private readonly ScenarioContext _context;

        #region Locators
        private By RecordAnotherGradeLink => By.LinkText("Record another grade");
        #endregion

        public AS_AssessmentRecordedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_RecordAGradePage ClickRecordAnotherGradeLinkInAssessmentRecordedPage()
        {
            formCompletionHelper.Click(RecordAnotherGradeLink);
            return new AS_RecordAGradePage(_context);
        }
    }
}
