namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_FeedbackOnYourWithdrawalNotificationStartPage : EPAO_BasePage
{
    protected override string PageTitle => "Feedback on your withdrawal request";

    public AS_FeedbackOnYourWithdrawalNotificationStartPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WithdrawalRequestOverviewPage ClickContinueButton()
    {
        Continue();
        return new AS_WithdrawalRequestOverviewPage(context);
    }
}
