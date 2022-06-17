namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public abstract class ApprenticeFeedbackBasePage : EmployerFeedbackBasePage
{

    protected static By RadioItems => By.CssSelector(".govuk-radios__item");

    protected static By ContinueToSubmitButton => By.CssSelector("button.govuk-button[type=submit]");

    public ApprenticeFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
    {

    }

    protected void ClickContinueButton() => formCompletionHelper.ClickButtonByText(ContinueToSubmitButton, "Continue");
}
