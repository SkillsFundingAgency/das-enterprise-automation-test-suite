namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WillYouCompleteEPAOForAllRegisteredLearnersPage : EPAO_BasePage
{
    protected override string PageTitle => "Will you complete the end-point assessments for all registered learners?";

    public AS_WillYouCompleteEPAOForAllRegisteredLearnersPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_HowWillYouCommunicateMarketExitToCustomersPage ClickYesAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByText("Yes");
        Continue();
        return new(context);
    }

    public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage ClickNoAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByText("No");
        Continue();
        return new(context);
    }
}