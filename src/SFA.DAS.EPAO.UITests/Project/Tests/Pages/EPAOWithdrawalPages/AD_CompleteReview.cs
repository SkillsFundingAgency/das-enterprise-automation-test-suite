namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AD_CompleteReview : EPAO_BasePage
{
    protected override string PageTitle => "Complete review";

    private static By ApproveApplicationButton => By.CssSelector("button.govuk-button");
    private static By AskForMoreInformationButton => By.CssSelector("button.govuk-button");

    public AD_CompleteReview(ScenarioContext context) : base(context) => VerifyPage();

    public AD_YouhaveApprovedThisWithdrawalNotification ClickApproveApplication()
    {
        formCompletionHelper.Click(ApproveApplicationButton);
        return new(context);
    }

    public AD_FeedbackSent ClickAddFeedback()
    {
        formCompletionHelper.Click(AskForMoreInformationButton);
        return new(context);
    }
}
