using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_InternalAuditPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Internal audit policy";

        private readonly ScenarioContext _context;

        public AS_InternalAuditPage(ScenarioContext context) : base(context) => _context = context;

        public AS_PublicLiabilityInsurancePage UploadAuditPolicy()
        {
            UploadFile();
            return new AS_PublicLiabilityInsurancePage(_context);
        }
    }
}
