namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_MonitoringProceduresPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Monitoring procedures";

    public AS_ModerationProcessesPage UploadMonitoringProcedure()
    {
        UploadFile();
        return new(context);
    }

    public AS_ModerationProcessesPage NHEI_UploadMonitoringProcedure()
    {
        UploadFile();
        return new(context);
    }
}
