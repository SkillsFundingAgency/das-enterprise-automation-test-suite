namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider;

public abstract class ProviderFeedbackBasePage : VerifyBasePage
{
    protected ProviderFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
    {
        if (verifypage) VerifyPage();
    }

    protected static By NavigationBarFeedbackLink => By.CssSelector(".app-navigation__link[href*='feedback']");

    protected static By ContinueToSubmitButton => By.CssSelector("button.govuk-button[type=submit]");

    protected void ClickContinueButton() => formCompletionHelper.ClickButtonByText(ContinueToSubmitButton, "Continue");

    public ApprenticeFeedbackSelectProviderPage NavigateToGiveFeedbackOnYourTrainingProvider()
    {
        formCompletionHelper.Click(NavigationBarFeedbackLink);
        return new(context);
    }
        
}