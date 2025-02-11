namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_PreventAgendaPolicyPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Prevent agenda policy";

    public AS_ConflictOfinterestPolicyPage UploadPreventAgendaPolicy()
    {
        UploadFile();
        return new(context);
    }

    public AS_ConflictOfinterestPolicyPage NHEI_UploadPreventAgendaPolicy()
    {
        UploadFile();
        return new(context);
    }
}
