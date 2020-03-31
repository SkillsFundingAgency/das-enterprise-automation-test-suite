using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ConsistencyAssurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Consistency assurance";

        private readonly ScenarioContext _context;

        public AS_ConsistencyAssurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_ImproveTheQualityPage UploadConsistencyAssurance()
        {
            UploadFile();
            return new AS_ImproveTheQualityPage(_context);
        }
    }
}
