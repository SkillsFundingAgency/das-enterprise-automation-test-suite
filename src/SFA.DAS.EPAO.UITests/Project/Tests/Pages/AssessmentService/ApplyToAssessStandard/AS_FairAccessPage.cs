namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_FairAccessPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Fair access";

    public AS_ConsistencyAssurancePage UploadFairAccess()
    {
        UploadFile();
        return new(context);
    }

    public AS_ConsistencyAssurancePage NHEI_UploadFairAccess()
    {
        UploadFile();
        return new(context);
    }

}