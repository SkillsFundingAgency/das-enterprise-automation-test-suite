using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_AssessmentPlanPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you undertake the individual elements of the assessment plan?";

        private readonly ScenarioContext _context;

        public AS_AssessmentPlanPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ReviewAndMaintainPage EnterAssessmentPlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ReviewAndMaintainPage(_context);
        }
    }
}
