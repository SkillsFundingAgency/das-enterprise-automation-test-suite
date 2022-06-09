namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_StandardSearchResultsPage : EPAO_BasePage
{
    protected override string PageTitle => "Standard search results";

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

    public AS_StandardSearchResultsPage(ScenarioContext context) : base(context) { }

    public AS_ConfirmAndApplyPage Apply()
    {
        tableRowHelper.SelectRowFromTable("Apply for standard", objectContext.GetApplyStandardName());
        return new AS_ConfirmAndApplyPage(context);
    }
}