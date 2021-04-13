using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class AccountingReferenceDatePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What's the accounting reference date for the financial information you are submitting?";
        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By AccountingReferenceDay => By.Id("FH-420");
        private By AccountingReferenceMonth => By.Id("FH-420_Month");
        private By AccountingReferenceYear => By.Id("FH-420_Year");

        public AccountingReferenceDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public HowManyMonthsAccountingPeriodPage EnterAccountingReferenceDateAndContinue()
        {
            var dobcalc = applydataHelpers.Dob(2);
            formCompletionHelper.EnterText(AccountingReferenceDay, dobcalc.Day);
            formCompletionHelper.EnterText(AccountingReferenceMonth, dobcalc.Month);
            formCompletionHelper.EnterText(AccountingReferenceYear, dobcalc.Year);
            Continue();
            return new HowManyMonthsAccountingPeriodPage(_context);
        }
    }
}
