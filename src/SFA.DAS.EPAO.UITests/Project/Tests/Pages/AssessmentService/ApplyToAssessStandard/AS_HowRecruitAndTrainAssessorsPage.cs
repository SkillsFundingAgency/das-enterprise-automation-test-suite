namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_HowRecruitAndTrainAssessorsPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How do you recruit and train assessors?";

    public AS_HowRecruitAndTrainAssessorsPage(ScenarioContext context) : base(context) { }

    public AS_ExperiencePage EnterHowRecruitAndTrainAssessors()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}
