using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_IndemnityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Professional indemnity insurance";

        private readonly ScenarioContext _context;

        public AS_IndemnityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_EmployersLiabilityInsurancePage UploadProfessionalIndemnityInsurance()
        {
            UploadFile();
            return new AS_EmployersLiabilityInsurancePage(_context);
        }
    }
}
