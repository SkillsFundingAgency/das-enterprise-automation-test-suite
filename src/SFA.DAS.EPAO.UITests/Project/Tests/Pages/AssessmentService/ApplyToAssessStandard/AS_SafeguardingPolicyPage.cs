namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_SafeguardingPolicyPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Safeguarding policy";

    public AS_PreventAgendaPolicyPage UploadSafeguardingPolicy()
    {
        UploadFile();
        return new(context);
    }

    public AS_PreventAgendaPolicyPage NHEI_UploadSafeguardingPolicy()
    {
        UploadFile();
        return new(context);
    }
}
