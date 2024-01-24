namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ConflictOfinterestPolicyPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Conflict of interest policy";

    public AS_MonitoringProceduresPage UploadConflictOfinterestPolicy()
    {
        UploadFile();
        return new(context);
    }

    public AS_MonitoringProceduresPage NHEI_UploadConflictOfinterestPolicy()
    {
        UploadFile();
        return new(context);
    }
}
