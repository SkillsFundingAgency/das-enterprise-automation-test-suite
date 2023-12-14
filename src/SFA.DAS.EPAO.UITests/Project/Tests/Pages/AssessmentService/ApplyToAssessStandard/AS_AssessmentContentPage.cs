namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_AssessmentContentPage(ScenarioContext context) : AS_EPAOApplyStandardBasePage(context)
{
    protected override string PageTitle => "Assessment content";

    public AS_ConfirmationOfAssessmentPage EnterAssessmentContent()
    {
        formCompletionHelper.EnterText(TextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_ConfirmationOfAssessmentPage NHEI_EnterAssessmentContent()
    {
        formCompletionHelper.EnterText(TextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

}