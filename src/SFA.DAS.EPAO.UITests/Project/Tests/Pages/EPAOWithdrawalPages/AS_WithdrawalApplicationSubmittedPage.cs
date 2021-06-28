using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalApplicationSubmittedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal notification submitted";
        
        public AS_WithdrawalApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    
        public void StandardSubmissionVerification() => VerifyPage();
    }
}