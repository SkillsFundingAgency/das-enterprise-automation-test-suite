namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ApplyToAssessStandardPage : EPAO_BasePage
{
    protected override string PageTitle => "Apply to assess a standard";

    private static By StartNow => By.CssSelector("a.govuk-button--start");

    public AS_ApplyToAssessStandardPage(ScenarioContext context) : base(context) { }

    public AS_SelectApplicationPage SelectApplication()
    {
        formCompletionHelper.ClickElement(StartNow);
        return new AS_SelectApplicationPage(context);
    }
}
