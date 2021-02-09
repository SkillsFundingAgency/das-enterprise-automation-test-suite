using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_FeedbackSent : EPAO_BasePage
    {
        protected override string PageTitle => "You've asked for more information";
       
        private readonly ScenarioContext _context;

        public AD_FeedbackSent(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplications()
        {
            formCompletionHelper.ClickLinkByText("Return to withdrawal applications");
            return new AD_WithdrawalApplicationsPage(_context);
        }
    }
}
