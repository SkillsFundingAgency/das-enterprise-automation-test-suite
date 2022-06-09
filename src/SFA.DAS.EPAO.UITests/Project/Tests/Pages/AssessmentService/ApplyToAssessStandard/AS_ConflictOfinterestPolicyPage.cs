namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ConflictOfinterestPolicyPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Conflict of interest policy";

    public AS_ConflictOfinterestPolicyPage(ScenarioContext context) : base(context) { }

    public AS_MonitoringProceduresPage UploadConflictOfinterestPolicy()
    {
        UploadFile();
        return new AS_MonitoringProceduresPage(context);
    }
}
