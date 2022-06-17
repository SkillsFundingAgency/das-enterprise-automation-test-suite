namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class GiveFeedbackOnATrainingProviderPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "Give feedback on";

    private static By StartNowButton => By.CssSelector("button.govuk-button[type=submit]");

    public GiveFeedbackOnATrainingProviderPage(ScenarioContext context) : base(context)
    {

    }

    public DoYouThinkTrainingProviderPage StartNow()
    {
        formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
        return new (context);
    }
}
