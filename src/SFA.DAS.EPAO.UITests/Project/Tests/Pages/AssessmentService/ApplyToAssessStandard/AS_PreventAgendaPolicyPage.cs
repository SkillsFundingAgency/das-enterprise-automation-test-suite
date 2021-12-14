using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_PreventAgendaPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Prevent agenda policy";

        public AS_PreventAgendaPolicyPage(ScenarioContext context) : base(context) { }

        public AS_ConflictOfinterestPolicyPage UploadPreventAgendaPolicy()
        {
            UploadFile();
            return new AS_ConflictOfinterestPolicyPage(context);
        }
    }
}
