namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_HowManyAssessorsPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "How many assessors will you have?";

    public AS_HowManyEndPointAssessmentPage EnterHowManyAssessors()
    {
        formCompletionHelper.EnterText(InputNumber, EPAOApplyStandardDataHelper.GenerateRandomWholeNumber(1));
        Continue();
        return new(context);
    }

    public AS_HowManyEndPointAssessmentPage NHEIEnterHowManyAssessors()
    {
        formCompletionHelper.EnterText(InputNumber, EPAOApplyStandardDataHelper.GenerateRandomWholeNumber(1));
        Continue();
        return new(context);
    }
}