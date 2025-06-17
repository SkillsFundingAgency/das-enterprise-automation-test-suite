namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ConsistencyAssurancePage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Consistency assurance";

    public AS_ImproveTheQualityPage UploadConsistencyAssurance()
    {
        UploadFile();
        return new(context);
    }

    public AS_ImproveTheQualityPage NHEI_UploadConsistencyAssurance()
    {
        UploadFile();
        return new(context);
    }
}