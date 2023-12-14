namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_DeliverEndPointPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How will you deliver an end-point assessment for this standard?";

    public AS_DeliverEndPointPage(ScenarioContext context) : base(context) { }

    public AS_IntendToOutsourcePage EnterDeliverEndPoint()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_IntendToOutsourcePage NHEI_EnterDeliverEndPoint()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}