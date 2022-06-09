namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AD_CheckTheWithdrawDatePage : EPAO_BasePage
{
    protected override string PageTitle => "Check the withdrawal date";

    protected override By ContinueButton => By.CssSelector(".govuk-button");

    private static By YesInput => By.CssSelector("#dateApproved-yes");

    public AD_CheckTheWithdrawDatePage(ScenarioContext context) : base(context) => VerifyPage();

    public AD_CompleteReview ContinueWithWithdrawalRequest()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(YesInput));
        Continue();
        return new AD_CompleteReview(context);
    }
}
