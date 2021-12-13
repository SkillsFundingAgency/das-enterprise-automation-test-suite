using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawFromAStandardOrTheRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdraw from a standard, version(s) or the register";
        
        public AS_WithdrawFromAStandardOrTheRegisterPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_YourWithdrawalRequestsPage ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
        {
            Continue();
            return new AS_YourWithdrawalRequestsPage(_context);
        }
    }
}
