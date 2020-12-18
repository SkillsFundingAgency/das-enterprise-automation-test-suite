using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_FeedbackSent : EPAO_BasePage
    {
        protected override string PageTitle => "Feedback sent";
       
        private readonly ScenarioContext _context;

        public AD_FeedbackSent(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
