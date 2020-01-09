using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CheckAndSubmitAssessmentPage : BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AS_CheckAndSubmitAssessmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_AssessmentRecordedPage ClickContinueInCheckAndSubmitAssessmentPage()
        {
            Continue();
            return new AS_AssessmentRecordedPage(_context);
        }
    }
}
