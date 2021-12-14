using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_SafeguardingPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Safeguarding policy";

        public AS_SafeguardingPolicyPage(ScenarioContext context) : base(context) { }

        public AS_PreventAgendaPolicyPage UploadSafeguardingPolicy()
        {
            UploadFile();
            return new AS_PreventAgendaPolicyPage(context);
        }
    }
}
