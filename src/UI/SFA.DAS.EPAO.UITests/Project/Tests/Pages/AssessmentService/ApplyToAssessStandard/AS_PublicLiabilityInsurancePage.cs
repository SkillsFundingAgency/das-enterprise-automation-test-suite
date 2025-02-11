namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_PublicLiabilityInsurancePage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Public liability insurance";

    public AS_IndemnityInsurancePage UploadPublicLiabilityInsurance()
    {
        UploadFile();
        return new(context);
    }

    public AS_IndemnityInsurancePage NHEIUploadPublicLiabilityInsurance()
    {
        UploadFile();
        return new(context);
    }
}