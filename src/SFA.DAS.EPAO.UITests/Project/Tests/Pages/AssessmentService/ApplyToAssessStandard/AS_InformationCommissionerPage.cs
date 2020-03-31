using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_InformationCommissionerPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Information commissioner's office (ICO) registration number";

        private readonly ScenarioContext _context;

        public AS_InformationCommissionerPage(ScenarioContext context) : base(context) => _context = context;

        public AS_InternalAuditPage EnterRegNumber()
        {
            formCompletionHelper.EnterText(InputText, standardDataHelper.GenerateRandomAlphanumericString(8));
            Continue();
            return new AS_InternalAuditPage(_context);
        }
    }
}
