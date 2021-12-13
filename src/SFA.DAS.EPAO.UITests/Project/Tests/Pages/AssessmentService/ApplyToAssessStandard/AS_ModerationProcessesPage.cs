using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ModerationProcessesPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Moderation processes";

        public AS_ModerationProcessesPage(ScenarioContext context) : base(context) { }

        public AS_ComplaintsAndAppealsPolicyPage UploadModerationProcesses()
        {
            UploadFile();
            return new AS_ComplaintsAndAppealsPolicyPage(context);
        }
    }
}
