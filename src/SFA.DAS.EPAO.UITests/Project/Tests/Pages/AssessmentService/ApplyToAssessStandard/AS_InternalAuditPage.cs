namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_InternalAuditPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Internal audit policy";

    public AS_InternalAuditPage(ScenarioContext context) : base(context) { }

    public AS_PublicLiabilityInsurancePage UploadAuditPolicy()
    {
        UploadFile();
        return new(context);
    }

    public AS_PublicLiabilityInsurancePage NHEI_UploadAuditPolicy()
    {
        UploadFile();
        return new(context);
    }
}
