namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_AssessmentContentPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Assessment content";

    public AS_AssessmentContentPage(ScenarioContext context) : base(context) { }

    public AS_ConfirmationOfAssessmentPage EnterAssessmentContent()
    {
        formCompletionHelper.EnterText(TextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new AS_ConfirmationOfAssessmentPage(context);
    }

}
