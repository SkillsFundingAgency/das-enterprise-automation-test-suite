namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_EngageWithEmployersPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How will you engage with employers and training organisations?";

    public AS_EngageWithEmployersPage(ScenarioContext context) : base(context) { }

    public AS_ManageAnyPotentialConflictPage EnterEngageWithEmployers()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

    public AS_ManageAnyPotentialConflictPage NHEI_EnterEngageWithEmployers()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }
}
