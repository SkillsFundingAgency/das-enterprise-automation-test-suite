using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithDrawConfirmationPage : FAABasePage
    {
        protected override string PageTitle => "Are you sure you want to withdraw your application?";

        public FAA_WithDrawConfirmationPage(ScenarioContext context) : base(context) { }

        public FAA_WithdrawSuccessfulPage YesWithdraw()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes, withdraw");
            formCompletionHelper.ClickButtonByText("Continue");
            return new FAA_WithdrawSuccessfulPage(context);
        }
    } 
}
