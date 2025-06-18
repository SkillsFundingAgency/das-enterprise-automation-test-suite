namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public abstract class AS_GradeDateBasePage : EPAOAssesment_BasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    #region Locators
    private static By DayTextBox => By.Id("Day");
    private static By MonthTextBox => By.Id("Month");
    private static By YearTextBox => By.Id("Year");
    #endregion

    public AS_GradeDateBasePage(ScenarioContext context) : base(context) => VerifyPage();

    /*PASS and FAIL scenarios return two different pages, so do NOT return any page for this method*/
    public void EnterAchievementGradeDateAndContinue() => EnterDateFieldsAndContinue();

    private void EnterDateFieldsAndContinue(bool invalidDateScenario = false)
    {
        formCompletionHelper.EnterText(DayTextBox, ePAOAssesmentServiceDataHelper.CurrentDay);
        formCompletionHelper.EnterText(MonthTextBox, ePAOAssesmentServiceDataHelper.CurrentMonth);
        if (invalidDateScenario) return;
        formCompletionHelper.EnterText(YearTextBox, ePAOAssesmentServiceDataHelper.CurrentYear);
        Continue();
    }
}
