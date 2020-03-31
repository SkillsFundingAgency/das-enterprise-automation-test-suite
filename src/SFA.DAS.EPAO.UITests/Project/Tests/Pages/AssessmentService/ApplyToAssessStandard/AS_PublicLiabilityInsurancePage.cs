using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_PublicLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Public liability insurance";

        private readonly ScenarioContext _context;

        public AS_PublicLiabilityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_IndemnityInsurancePage UploadPublicLiabilityInsurance()
        {
            UploadFile();
            return new AS_IndemnityInsurancePage(_context);
        }
    }
}
