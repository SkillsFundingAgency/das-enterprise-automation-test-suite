namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackGiveFeedbackPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "Give feedback on";

    private static By StartNowButton => By.CssSelector("button.govuk-button[type=submit]");

    public ApprenticeFeedbackGiveFeedbackPage(ScenarioContext context) : base(context)
    {

    }

    public ApprenticeFeedbackDoYouThinkPage StartNow()
    {
        formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
        return new (context);
    }
}
