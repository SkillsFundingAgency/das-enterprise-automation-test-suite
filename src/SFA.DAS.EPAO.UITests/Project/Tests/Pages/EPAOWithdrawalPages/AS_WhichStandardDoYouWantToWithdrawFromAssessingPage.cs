namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_CheckWithdrawalRequestPage : EPAO_BasePage
{
    protected override string PageTitle => "Check withdrawal request";

    private static By ConfirmRequest => By.CssSelector(".govuk-radios__label[for='confirm-withdrawal-request']");

    public AS_CheckWithdrawalRequestPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WithdrawalRequestOverviewPage ContinueWithWithdrawalRequest()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmRequest));

        Continue();

        return new(context);
    }
}


public class AS_WhichStandardDoYouWantToWithdrawFromAssessingPage : EPAO_BasePage
{
    protected override string PageTitle => "Which standard do you want to withdraw from assessing?";

    public AS_WhichStandardDoYouWantToWithdrawFromAssessingPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_CheckWithdrawalRequestPage ClickASpecificStandardToWithdraw()
    {
        tableRowHelper.SelectRowFromTable("Select", "Brewer (Level 4)");

        return new(context);
    }
}
