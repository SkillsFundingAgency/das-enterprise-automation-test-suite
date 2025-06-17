namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public abstract class AS_EPAOApplyStandardBasePage : EPAO_BasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-label--xl");

    protected static By InputText => By.CssSelector(".govuk-input[type='text']");

    protected static By InputNumber => By.CssSelector(".govuk-input[type='number']");

    protected static By TextArea => By.CssSelector(".govuk-textarea");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

    public AS_EPAOApplyStandardBasePage(ScenarioContext context) : base(context) { VerifyPage(); }

    protected void SelectAndContinue(string option)
    {
        SelectRadioOptionByText(option);
        Continue();
    }
}
