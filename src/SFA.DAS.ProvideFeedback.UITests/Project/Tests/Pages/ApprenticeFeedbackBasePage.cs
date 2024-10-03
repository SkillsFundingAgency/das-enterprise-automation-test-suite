namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public abstract class ApprenticeFeedbackBasePage(ScenarioContext context, bool verifypage = true) : EmployerFeedbackBasePage(context, verifypage)
{
    protected static By NavigationBarFeedbackLink => By.CssSelector(".app-navigation__link[href*='feedback']");

    protected static By ContinueToSubmitButton => By.CssSelector("button.govuk-button[type=submit]");

    protected void ClickContinueButton() => formCompletionHelper.ClickButtonByText(ContinueToSubmitButton, "Continue");

    public ApprenticeFeedbackSelectProviderPage NavigateToGiveFeedbackOnYourTrainingProvider()
    {
        formCompletionHelper.Click(NavigationBarFeedbackLink);
        return new(context);
    }
}
