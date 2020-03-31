using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_SecureITInfrastructurePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Secure IT infrastructure";

        private readonly ScenarioContext _context;

        public AS_SecureITInfrastructurePage(ScenarioContext context) : base(context) => _context = context;

        public AS_AssessmentAdministrationPage EnterSecureITInfrastructurePlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentAdministrationPage(_context);
        }

    }
}
