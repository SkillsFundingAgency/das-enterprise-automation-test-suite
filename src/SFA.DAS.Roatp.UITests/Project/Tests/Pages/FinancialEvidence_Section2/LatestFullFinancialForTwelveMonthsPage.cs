using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class LatestFullFinancialForTwelveMonthsPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation produced its latest full financial statements covering a minimum of 12 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public LatestFullFinancialForTwelveMonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinanicialStatementsCoveringAnyPeriodPage SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new FinanicialStatementsCoveringAnyPeriodPage(_context);
        }
    }
}
