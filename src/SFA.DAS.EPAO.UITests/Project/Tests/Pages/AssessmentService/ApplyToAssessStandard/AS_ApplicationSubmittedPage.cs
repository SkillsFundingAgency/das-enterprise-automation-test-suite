namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ApplicationSubmittedPage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => "Stage 2 of your application has been submitted";

    protected override By PageHeader => PanelTitle;
}
