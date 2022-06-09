namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ConsistencyAssurancePage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Consistency assurance";

    public AS_ConsistencyAssurancePage(ScenarioContext context) : base(context) { }

    public AS_ImproveTheQualityPage UploadConsistencyAssurance()
    {
        UploadFile();
        return new AS_ImproveTheQualityPage(context);
    }
}
