using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithDrawConfirmationPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Are you sure you want to withdraw your application?";

        public FAA_WithdrawSuccessfulPage YesWithdraw()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes, withdraw");
            formCompletionHelper.ClickButtonByText("Continue");
            return new FAA_WithdrawSuccessfulPage(context);
        }
    } 
}
