namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_SecureITInfrastructurePage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Secure IT infrastructure";

    public AS_SecureITInfrastructurePage(ScenarioContext context) : base(context) { }

    public AS_AssessmentAdministrationPage EnterSecureITInfrastructurePlan()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_AssessmentAdministrationPage NHEI_EnterSecureITInfrastructurePlan()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

}