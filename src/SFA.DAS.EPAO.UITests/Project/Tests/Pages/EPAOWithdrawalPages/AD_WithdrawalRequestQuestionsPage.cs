namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AD_WithdrawalRequestQuestionsPage : EPAO_BasePage
{
    protected override string PageTitle => "Withdrawal request questions";

    private static By SaveButton => By.CssSelector("button.govuk-button");

    private static By AddFeedbackHowWillYouSupportLearnersLink => By.XPath("//dd/h3[contains(text(),\"How will you support the learners you are not going to assess?\")]/../following-sibling::dd/p/a");

    public AD_WithdrawalRequestQuestionsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AD_WithdrawalRequestOverviewPage MarkCompleteAndGoToWithdrawalApplicationOverviewPage()
    {
        formCompletionHelper.SelectRadioOptionByText("Yes");
        formCompletionHelper.Click(SaveButton);
        return new(context);
    }

    public AD_HowWillYouSupportTheLearnersYouAreNotGoingToAssess ClickAddFeedbackToHowWillYouSupportLearnersQuestion()
    {
        formCompletionHelper.Click(AddFeedbackHowWillYouSupportLearnersLink);
        return new(context);
    }
}
