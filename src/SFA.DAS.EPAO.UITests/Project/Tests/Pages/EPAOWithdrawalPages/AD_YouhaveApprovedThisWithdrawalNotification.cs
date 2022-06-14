namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AD_YouhaveApprovedThisWithdrawalNotification : EPAO_BasePage
{
    protected override string PageTitle => "You've approved this withdrawal application";

    private static By ReturnToApprovedWithdrawals => By.CssSelector("a[href='/WithdrawalApplication/WithdrawalApplications#approved']");

    private static By WithdrawlFromRegisterApprovedMessage => By.XPath("//p[contains(text(), \"to withdraw from the register of end-point assessment organisations.\")]");

    public AD_YouhaveApprovedThisWithdrawalNotification(ScenarioContext context) : base(context) => VerifyPage();

    public AD_YouhaveApprovedThisWithdrawalNotification VerifyRegisterWithdrawalBodyText()
    {
        Assert.IsNotNull(pageInteractionHelper.FindElement(WithdrawlFromRegisterApprovedMessage));
        return this;
    }

    public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplications()
    {
        formCompletionHelper.ClickElement(ReturnToApprovedWithdrawals);
        return new(context);
    }
}
