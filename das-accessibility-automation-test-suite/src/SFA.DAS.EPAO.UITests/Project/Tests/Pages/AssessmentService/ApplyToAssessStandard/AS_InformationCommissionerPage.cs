namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_InformationCommissionerPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Information commissioner's office (ICO) registration number";

    public AS_InternalAuditPage EnterRegNumber()
    {
        formCompletionHelper.EnterText(InputText, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(8));
        Continue();
        return new(context);
    }

    public AS_PublicLiabilityInsurancePage NHEIEnterRegNumber()
    {
        formCompletionHelper.EnterText(InputText, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(8));
        Continue();
        return new(context);
    }
}
