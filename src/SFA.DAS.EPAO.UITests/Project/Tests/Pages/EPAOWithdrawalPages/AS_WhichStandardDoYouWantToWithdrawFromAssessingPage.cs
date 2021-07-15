using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhichStandardDoYouWantToWithdrawFromAssessingPage : EPAO_BasePage
    {
        protected override string PageTitle => "Which standard do you want to withdraw from assessing?";
        private readonly ScenarioContext _context;

        public AS_WhichStandardDoYouWantToWithdrawFromAssessingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WithdrawalRequestOverviewPage ClickASpecificStandardToWithdraw()
        {
            tableRowHelper.SelectRowFromTable("Select", "Brewer (Level 4)");

            Continue();

            return new AS_WithdrawalRequestOverviewPage(_context);
        }
    }
}
