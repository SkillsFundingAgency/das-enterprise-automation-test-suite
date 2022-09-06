namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ImproveTheQualityPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How do you continuously improve the quality of your assessment practice?";

    public AS_ImproveTheQualityPage(ScenarioContext context) : base(context) { }

    public AS_EngagementWithTrailblazersAndEmployersPage EnterImproveTheQuality()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_EngagementWithTrailblazersAndEmployersPage NHEI_EnterImproveTheQuality()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}