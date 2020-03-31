using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_OccupationalExpertisePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you ensure your assessors' occupational expertise is maintained and kept current?";

        private readonly ScenarioContext _context;

        public AS_OccupationalExpertisePage(ScenarioContext context) : base(context) => _context = context;

        public AS_DeliverEndPointPage EnterOccupationalExpertise()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_DeliverEndPointPage(_context);
        }
    }
}
