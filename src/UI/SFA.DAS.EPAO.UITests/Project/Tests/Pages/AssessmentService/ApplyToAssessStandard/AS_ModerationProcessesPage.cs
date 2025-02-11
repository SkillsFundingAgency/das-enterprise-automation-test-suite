namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ModerationProcessesPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Moderation processes";

    public AS_ComplaintsAndAppealsPolicyPage UploadModerationProcesses()
    {
        UploadFile();
        return new(context);
    }

    public AS_ComplaintsAndAppealsPolicyPage NHEI_UploadModerationProcesses()
    {
        UploadFile();
        return new(context);
    }
}
