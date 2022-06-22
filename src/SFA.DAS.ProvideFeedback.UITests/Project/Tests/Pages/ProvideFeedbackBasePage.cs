namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public abstract class ProvideFeedbackBasePage : VerifyBasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");


    public ProvideFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }
}
