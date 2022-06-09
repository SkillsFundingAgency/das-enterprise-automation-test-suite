namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_PublicLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Public liability insurance";

    public AS_PublicLiabilityInsurancePage(ScenarioContext context) : base(context) { }

    public AS_IndemnityInsurancePage UploadPublicLiabilityInsurance()
    {
        UploadFile();
        return new(context);
    }
}
