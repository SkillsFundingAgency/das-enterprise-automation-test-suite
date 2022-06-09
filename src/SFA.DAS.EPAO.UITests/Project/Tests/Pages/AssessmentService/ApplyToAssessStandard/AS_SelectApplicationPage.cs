namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_SelectApplicationPage : EPAO_BasePage
{
    protected override string PageTitle => "Select application";

    private static By StartApplicationLink => By.CssSelector("#main-content .govuk-button[type='submit']");

    public AS_SelectApplicationPage(ScenarioContext context) : base(context) { }

    public AS_ApplyForAStandardPage StartApplication()
    {
        formCompletionHelper.ClickElement(StartApplicationLink);
        return new AS_ApplyForAStandardPage(context);
    }

    public AS_ApplicationOverviewPage SelectApplication()
    {
        tableRowHelper.SelectRowFromTable("View", objectContext.GetApplyStandardName());
        return new AS_ApplicationOverviewPage(context);
    }
}
