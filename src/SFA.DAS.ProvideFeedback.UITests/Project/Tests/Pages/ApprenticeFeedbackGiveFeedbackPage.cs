namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackGiveFeedbackPage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
{
    protected override string PageTitle => "Give feedback on";

    private static By StartNowButton => By.CssSelector("button.govuk-button[type=submit]");

    public ApprenticeFeedbackDoYouThinkPage StartNow()
    {
        formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
        return new (context);
    }
}
