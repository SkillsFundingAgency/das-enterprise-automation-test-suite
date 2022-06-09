namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_MonitoringProceduresPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Monitoring procedures";

    public AS_MonitoringProceduresPage(ScenarioContext context) : base(context) { }

    public AS_ModerationProcessesPage UploadMonitoringProcedure()
    {
        UploadFile();
        return new AS_ModerationProcessesPage(context);
    }

}
