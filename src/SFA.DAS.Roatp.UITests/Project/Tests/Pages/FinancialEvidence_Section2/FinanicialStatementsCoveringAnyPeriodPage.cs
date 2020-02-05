using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{

    public class FinanicialStatementsCoveringAnyPeriodPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation produced financial statements covering any period within the last 12 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinanicialStatementsCoveringAnyPeriodPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhatYouNeedToUploadPage ClickYesForFinancialStatementsCoveringAnyPeriodAndContinue() => FinancialStatementsCoveringAnyPeriodAndContinue("Yes");

        public WhatYouNeedToUploadPage ClickNoForFinancialStatementsCoveringAnyPeriodAndContinue() => FinancialStatementsCoveringAnyPeriodAndContinue("No");

        public FullManagementAccountsPage SelectNoForFinancialStatementsCoveringAnyPeriod_SupportingAndContinue()
        {
            SelectNoAndContinue();
            return new FullManagementAccountsPage(_context);
        }

        private WhatYouNeedToUploadPage FinancialStatementsCoveringAnyPeriodAndContinue(string option)
        {
            SelectRadioOptionByText(option);
            Continue();
            return new WhatYouNeedToUploadPage(_context);
        }
    }
}
