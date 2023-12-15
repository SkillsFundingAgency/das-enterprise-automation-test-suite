namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ApplicationOverviewPage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => "Application overview";

    public AS_ApplyToStandardPage GoToApplyToStandard()
    {
        formCompletionHelper.ClickLinkByText("Go to apply to assess a standard");
        return new(context);
    }

    public AS_ApplicationSubmittedPage Submit()
    {
        Continue();
        return new(context);
    }
}
