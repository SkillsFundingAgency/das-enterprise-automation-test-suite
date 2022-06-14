namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AD_FeedbackSent : EPAO_BasePage
{
    protected override string PageTitle => "You've asked for more information";

    public AD_FeedbackSent(ScenarioContext context) : base(context) => VerifyPage();

    public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplications()
    {
        formCompletionHelper.ClickLinkByText("Return to withdrawal applications");
        return new(context);
    }
}
