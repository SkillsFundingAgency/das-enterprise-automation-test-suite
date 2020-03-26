using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ConfirmationOfAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Collation and confirmation of assessment outcomes";

        private readonly ScenarioContext _context;

        public AS_ConfirmationOfAssessmentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_RecordingAssessmentResultsPage EnterCollationOutcome()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_RecordingAssessmentResultsPage(_context);
        }
    }
}
