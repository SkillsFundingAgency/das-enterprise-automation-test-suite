using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_DeliverEndPointPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you deliver an end-point assessment for this standard?";

        private readonly ScenarioContext _context;

        public AS_DeliverEndPointPage(ScenarioContext context) : base(context) => _context = context;

        public AS_IntendToOutsourcePage EnterDeliverEndPoint()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_IntendToOutsourcePage(_context);
        }
    }
}
