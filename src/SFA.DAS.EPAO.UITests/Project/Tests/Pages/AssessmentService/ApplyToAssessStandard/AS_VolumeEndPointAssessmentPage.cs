namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_VolumeEndPointAssessmentPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How will the volume of end-point assessments be achieved with the number of assessors you will have?";

    public AS_VolumeEndPointAssessmentPage(ScenarioContext context) : base(context) { }

    public AS_HowRecruitAndTrainAssessorsPage EnterVolume()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}
