namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ManageAnyPotentialConflictPage : AS_EPAOApplyStandardBasePage
{
    protected override string PageTitle => "How will you manage any potential conflict of interest, particular to other functions your organisation may have?";

    public AS_ManageAnyPotentialConflictPage(ScenarioContext context) : base(context) { }

    public AS_WhereWillYouDeliverEndPointAssessmentsPage EnterManageAnyPotentialConflict()
    {
        formCompletionHelper.EnterText(TextArea, EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(80));
        Continue();
        return new(context);
    }

}
