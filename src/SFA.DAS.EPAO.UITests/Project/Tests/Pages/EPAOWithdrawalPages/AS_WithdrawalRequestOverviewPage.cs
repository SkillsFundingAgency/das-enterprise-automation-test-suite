namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WithdrawalRequestOverviewPage : EPAO_BasePage
{
    protected override string PageTitle => "Withdrawal request overview";

    #region Locators
    private static By StandardNameVerification => By.XPath("//*[contains(text(),'ST0580 Brewer')]");
    private static By InitialQuestionsCompletedVerification => By.XPath("//*[contains(text(),'0 of 4 questions completed')]");
    private static By TotalQuestionsCompletedVerification => By.XPath("//*[contains(text(),'4 of 4 questions completed')]");
    private static By TotalQuestionsWithAdditionalHowWillYouSupportLearnersCompletedVerification => By.XPath("//*[contains(text(),'5 of 5 questions completed')]");
    private static By StartStandardWithdrawalQuestions => By.LinkText("Go to withdrawal request questions");
    private static By StartOrganisationWithdrawalQuestions => By.LinkText("Go to withdrawal request questions");
    private static By AmmedSupportingCurrentLearnersAnswer => By.XPath("//strong/../span/a[contains(text(), 'Supporting current learners')]");
    #endregion
    public AS_WithdrawalRequestOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WithdrawalRequestQuestionsPage ClickGoToStandardWithdrawalQuestions()
    {
        VerifyElement(StandardNameVerification, "ST0580 Brewer");
        VerifyElement(InitialQuestionsCompletedVerification, "0 of 4 questions completed");
        formCompletionHelper.Click(StartStandardWithdrawalQuestions);
        return new AS_WithdrawalRequestQuestionsPage(context);
    }

    public AS_WithdrawalRequestQuestionsPage ClickGoToRegisterWithdrawalQuestions()
    {
        VerifyElement(PageCaptionXl, "Withdrawing from register");
        VerifyElement(InitialQuestionsCompletedVerification, "0 of 4 questions completed");
        formCompletionHelper.Click(StartOrganisationWithdrawalQuestions);
        return new AS_WithdrawalRequestQuestionsPage(context);
    }

    public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage ClickSupportingCurrentLearnersFeedback()
    {
        formCompletionHelper.Click(AmmedSupportingCurrentLearnersAnswer);
        return new AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage(context);
    }

    public void AcceptAndSubmit()
    {
        VerifyElement(TotalQuestionsCompletedVerification, "4 of 4 questions completed");
        Continue();
    }

    public void SubmitUpdatedAnswers() => Continue();

    public void AcceptAndSubmitWithHowWillYouSuportQuestion()
    {
        VerifyElement(TotalQuestionsWithAdditionalHowWillYouSupportLearnersCompletedVerification, "5 of 5 questions completed");
        Continue();
    }
}