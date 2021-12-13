using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class LatestFullFinancialForTwelveMonthsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation produced its latest full financial statements covering a minimum of 12 months?";

        public LatestFullFinancialForTwelveMonthsPage(ScenarioContext context) : base(context) => VerifyPage();

        public FinanicialStatementsCoveringAnyPeriodPage SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new FinanicialStatementsCoveringAnyPeriodPage(_context);
        }
    }
}
