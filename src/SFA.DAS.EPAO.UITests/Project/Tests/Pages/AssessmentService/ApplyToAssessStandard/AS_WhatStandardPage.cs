namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_WhatStandardPage : EPAO_BasePage
{
    protected override string PageTitle => "What standard are you applying for?";

    protected override By PageHeader => By.CssSelector(".govuk-label--xl");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

    private static By StandardName => By.CssSelector("#standard-name");

    public AS_WhatStandardPage(ScenarioContext context) : base(context) { }

    public AS_StandardSearchResultsPage EnterStandardName()
    {
        formCompletionHelper.EnterText(StandardName, objectContext.GetApplyStandardName());
        Continue();
        return new(context);
    }

    public AS_StandardSearchResultsPage EnterStandardToCancelName()
    {
        formCompletionHelper.EnterText(StandardName, "Brewer");
        Continue();
        return new(context);
    }
}