namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_EmployersLiabilityInsurancePage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Employers liability insurance";

    public AS_SafeguardingPolicyPage UploadEmployersLiabilityInsurance()
    {
        UploadFile();
        return new(context);
    }

    public AS_HowManyAssessorsPage NHEIUploadEmployersLiabilityInsurance()
    {
        UploadFile();
        return new(context);
    }
}
