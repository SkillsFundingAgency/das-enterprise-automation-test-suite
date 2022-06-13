namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_IndemnityInsurancePage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Professional indemnity insurance";

    public AS_IndemnityInsurancePage(ScenarioContext context) : base(context) { }

    public AS_EmployersLiabilityInsurancePage UploadProfessionalIndemnityInsurance()
    {
        UploadFile();
        return new(context);
    }
}
