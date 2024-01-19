namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_SelectApplicationPage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => "Select application";

    private static By StartApplicationLink => By.CssSelector("#main-content .govuk-button[type='submit']");

    public AS_ApplyForAStandardPage StartApplication()
    {
        formCompletionHelper.ClickElement(StartApplicationLink);
        return new(context);
    }

    public AS_ApplicationOverviewPage SelectApplication()
    {
        tableRowHelper.SelectRowFromTable("View", objectContext.GetApplyStandardName());
        return new(context);
    }
}
