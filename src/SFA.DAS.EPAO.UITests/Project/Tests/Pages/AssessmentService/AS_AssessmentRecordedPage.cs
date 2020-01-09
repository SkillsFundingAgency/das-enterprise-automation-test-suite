using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AssessmentRecordedPage : BasePage
    {
        protected override string PageTitle => "Assessment recorded";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By RecordAnotherGradeLink => By.LinkText("Record another grade");
        #endregion

        public AS_AssessmentRecordedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_RecordAGradePage ClickRecordAnotherGradeLinkInAssessmentRecordedPage()
        {
            _formCompletionHelper.Click(RecordAnotherGradeLink);
            return new AS_RecordAGradePage(_context);
        }
    }
}
