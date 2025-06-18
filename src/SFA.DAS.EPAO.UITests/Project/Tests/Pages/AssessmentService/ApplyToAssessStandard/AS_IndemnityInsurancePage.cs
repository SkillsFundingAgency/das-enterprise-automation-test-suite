namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_IndemnityInsurancePage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Professional indemnity insurance";

    public AS_EmployersLiabilityInsurancePage UploadProfessionalIndemnityInsurance()
    {
        UploadFile();
        return new(context);
    }

    public AS_EmployersLiabilityInsurancePage NHEIUploadProfessionalIndemnityInsurance()
    {
        UploadFile();
        return new(context);
    }
}
