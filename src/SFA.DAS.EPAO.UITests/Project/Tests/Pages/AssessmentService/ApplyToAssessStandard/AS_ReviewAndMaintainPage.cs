using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ReviewAndMaintainPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you continuously review and maintain the required resources and assessment tools?";

        private readonly ScenarioContext _context;

        public AS_ReviewAndMaintainPage(ScenarioContext context) : base(context) => _context = context;

        public AS_SecureITInfrastructurePage EnterReviewAndMaintainPlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_SecureITInfrastructurePage(_context);
        }
    }
}
