using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class HowManyMonthsAccountingPeriodPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How many months does the accounting period cover for the financial information you are submitting?";
        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MonthBox => By.CssSelector("input[type='number']");

        public HowManyMonthsAccountingPeriodPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterMonthsForAccountingPeriodAndContinue()
        {
            formCompletionHelper.EnterText(MonthBox, applydataHelpers.NumberBetween1And23);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
