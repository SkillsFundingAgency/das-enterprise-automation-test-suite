namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WithdrawFromAStandardOrTheRegisterPage : EPAO_BasePage
{
    protected override string PageTitle => "Withdraw from a standard or the register";

    public AS_WithdrawFromAStandardOrTheRegisterPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhatAreYouWithdrawingFromPage ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenNoWithdrawalsExist()
    {
        Continue();
        return new(context);
    }

    public AS_YourWithdrawalRequestsPage ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenWithdrawalsExist()
    {
        Continue();
        return new(context);
    }
}
