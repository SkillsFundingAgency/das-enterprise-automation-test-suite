namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ReviewAndMaintainPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How will you continuously review and maintain the required resources and assessment tools?";

    public AS_ReviewAndMaintainPage(ScenarioContext context) : base(context) { }

    public AS_SecureITInfrastructurePage EnterReviewAndMaintainPlan()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
    
    public AS_SecureITInfrastructurePage NHEI_EnterReviewAndMaintainPlan()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}
