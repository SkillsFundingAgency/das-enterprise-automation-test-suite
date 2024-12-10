namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WithdrawFromAStandardsPage : EPAO_BasePage
{
    protected override string PageTitle => "Withdraw from standards";

    public AS_WithdrawFromAStandardsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhatAreYouWithdrawingFromPage ClickContinueOnWithdrawFromStandardsPageWhenNoWithdrawalsExist()
    {
        Continue();
        return new(context);
    }

    public AS_YourWithdrawalRequestsPage ClickContinueOnWithdrawFromStandardsPageWhenWithdrawalsExist()
    {
        Continue();
        return new(context);
    }
}
