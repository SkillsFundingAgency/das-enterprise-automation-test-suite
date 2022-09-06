namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_AssessmentAdministrationPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "Assessment administration";

    public AS_AssessmentAdministrationPage(ScenarioContext context) : base(context) { }

    public AS_AssessmentProductsAndToolsPage EnterAssessmentAdministration()
    {
        formCompletionHelper.EnterText(TextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
    
    public AS_AssessmentProductsAndToolsPage NHEI_EnterAssessmentAdministration()
    {
        formCompletionHelper.EnterText(TextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}