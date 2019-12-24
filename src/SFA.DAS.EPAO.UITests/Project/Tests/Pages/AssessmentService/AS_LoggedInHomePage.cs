using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LoggedInHomePage : BasePage
    {
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;

        #endregion

        #region Locators
        private By RecordAGradeLink => By.Id("Record a grade");
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
    }
}
