namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_EmployersLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Employers liability insurance";

    public AS_EmployersLiabilityInsurancePage(ScenarioContext context) : base(context) { }

    public AS_SafeguardingPolicyPage UploadEmployersLiabilityInsurance()
    {
        UploadFile();
        return new AS_SafeguardingPolicyPage(context);
    }
}
