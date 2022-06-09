namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_HowManyAssessorsPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How many assessors will you have?";

    public AS_HowManyAssessorsPage(ScenarioContext context) : base(context) { }

    public AS_HowManyEndPointAssessmentPage EnterHowManyAssessors()
    {
        formCompletionHelper.EnterText(InputNumber, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomWholeNumber(1));
        Continue();
        return new AS_HowManyEndPointAssessmentPage(context);
    }
}
