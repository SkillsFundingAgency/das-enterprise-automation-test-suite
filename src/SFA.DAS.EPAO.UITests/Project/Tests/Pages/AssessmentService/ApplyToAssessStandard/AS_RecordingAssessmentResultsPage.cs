namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_RecordingAssessmentResultsPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Recording assessment results";

    public AS_RecordingAssessmentResultsPage(ScenarioContext context) : base(context) { }

    public AS_EnterYourWebAddressPage EnterAssessmentResutls()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_EnterYourWebAddressPage NHEI_EnterAssessmentResutls()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}