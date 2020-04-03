using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_SafeguardingPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Safeguarding policy";

        private readonly ScenarioContext _context;

        public AS_SafeguardingPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_PreventAgendaPolicyPage UploadSafeguardingPolicy()
        {
            UploadFile();
            return new AS_PreventAgendaPolicyPage(_context);
        }
    }
}
