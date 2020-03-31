using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_MonitoringProceduresPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Monitoring procedures";

        private readonly ScenarioContext _context;

        public AS_MonitoringProceduresPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ModerationProcessesPage UploadMonitoringProcedure()
        {
            UploadFile();
            return new AS_ModerationProcessesPage(_context);
        }

    }
}
