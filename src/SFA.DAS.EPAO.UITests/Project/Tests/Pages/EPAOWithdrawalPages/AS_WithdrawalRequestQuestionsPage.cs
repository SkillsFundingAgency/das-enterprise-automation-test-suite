namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WithdrawalRequestQuestionsPage : EPAO_BasePage
{
    protected override string PageTitle => "Withdrawal request questions";

    private static string CompletedStatus => "COMPLETED";

    #region Locators
    private static By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
    private static By GoToReasonForWithdrawingQuestionsLink => By.LinkText("Reason for withdrawing");
    private static By ReaasonForWithdrawingCompletedVerification => By.XPath("//a[contains(text(), 'Reason for withdrawing')]/../following-sibling::strong");
    private static By CompletingAssessmentsForLearnersCompletedVerification => By.XPath("//a[contains(text(), 'Completing assessments for registered learners')]/../following-sibling::strong");
    private static By CommunicatingMarketExitCompletedVerification => By.XPath("//a[contains(text(), 'Communicating your market exit to customers')]/../following-sibling::strong");
    private static By WithdrawalDateCompletedVerification => By.XPath("//a[contains(text(), 'Withdrawal date')]/../following-sibling::strong");
    private static By SupportingLearnersVerification => By.XPath("//a[contains(text(), 'Supporting current learners')]/../following-sibling::strong");
    private static By ReturnToApplicationOverviewButton => By.LinkText("Return to application overview");
    #endregion

    public AS_WithdrawalRequestQuestionsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage ClickGoToReasonForWithdrawingQuestionLink()
    {
        VerifyElement(StandardNameVerification, "ST0580 Brewer");
        formCompletionHelper.Click(GoToReasonForWithdrawingQuestionsLink);
        return new(context);
    }

    public AS_WhatIsTheMainReasonYouWantToWithdrawFromTheRegisterPage ClickGoToReasonForWithdrawingFromRegisterQuestionLink()
    {
        formCompletionHelper.Click(GoToReasonForWithdrawingQuestionsLink);
        return new(context);
    }

    public AS_WithdrawalRequestOverviewPage VerifyAndReturnToApplicationOverviewPage()
    {
        VerifyElement(ReaasonForWithdrawingCompletedVerification, CompletedStatus);
        VerifyElement(CompletingAssessmentsForLearnersCompletedVerification, CompletedStatus);
        VerifyElement(CommunicatingMarketExitCompletedVerification, CompletedStatus);
        VerifyElement(WithdrawalDateCompletedVerification, CompletedStatus);
        formCompletionHelper.Click(ReturnToApplicationOverviewButton);
        return new(context);
    }

    public AS_WithdrawalRequestOverviewPage VerifyWithSupportingLearnersQuestionAndReturnToApplicationOverviewPage()
    {
        VerifyElement(ReaasonForWithdrawingCompletedVerification, CompletedStatus);
        VerifyElement(CompletingAssessmentsForLearnersCompletedVerification, CompletedStatus);
        VerifyElement(CommunicatingMarketExitCompletedVerification, CompletedStatus);
        VerifyElement(WithdrawalDateCompletedVerification, CompletedStatus);
        VerifyElement(SupportingLearnersVerification, CompletedStatus);
        formCompletionHelper.Click(ReturnToApplicationOverviewButton);
        return new(context);
    }
}