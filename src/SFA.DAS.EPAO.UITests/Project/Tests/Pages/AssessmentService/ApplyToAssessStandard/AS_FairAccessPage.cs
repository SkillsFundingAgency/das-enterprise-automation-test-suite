using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_FairAccessPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Fair access";

        private readonly ScenarioContext _context;

        public AS_FairAccessPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConsistencyAssurancePage UploadFairAccess()
        {
            UploadFile();
            return new AS_ConsistencyAssurancePage(_context);
        }

    }
}
