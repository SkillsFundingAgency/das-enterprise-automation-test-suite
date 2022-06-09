namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_HowWillYouCommunicateMarketExitToCustomersPage : EPAO_BasePage
{
    protected override string PageTitle => "How will you communicate your market exit to customers?";

    #region Locators
    private static By SupportInfoTextArea => By.XPath("//div[@class='govuk-character-count']//textarea");
    #endregion

    public AS_HowWillYouCommunicateMarketExitToCustomersPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhenDoYouWantToWithdrawFromTheStandardPage EnterSupportingInformationForStandardWithdrawal()
    {
        formCompletionHelper.Click(SupportInfoTextArea);
        formCompletionHelper.EnterText(SupportInfoTextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(250));
        Continue();
        return new AS_WhenDoYouWantToWithdrawFromTheStandardPage(context);
    }

    public AS_WhenDoYouWantToWithdrawFromTheRegisterPage EnterSupportingInformationForRegisterWithdrawal()
    {
        formCompletionHelper.Click(SupportInfoTextArea);
        formCompletionHelper.EnterText(SupportInfoTextArea, Helpers.DataHelpers.EPAOApplyStandardDataHelper.GenerateRandomAlphanumericString(250));
        Continue();
        return new AS_WhenDoYouWantToWithdrawFromTheRegisterPage(context);
    }
}