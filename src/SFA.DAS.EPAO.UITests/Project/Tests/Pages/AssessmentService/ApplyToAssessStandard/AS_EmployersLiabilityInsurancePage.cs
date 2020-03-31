using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_EmployersLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Employers liability insurance";

        private readonly ScenarioContext _context;

        public AS_EmployersLiabilityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_SafeguardingPolicyPage UploadEmployersLiabilityInsurance()
        {
            UploadFile();
            return new AS_SafeguardingPolicyPage(_context);
        }
    }
}
