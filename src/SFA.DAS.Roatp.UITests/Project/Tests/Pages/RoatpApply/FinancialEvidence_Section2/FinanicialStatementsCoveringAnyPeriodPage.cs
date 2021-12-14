using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{

    public class FinanicialStatementsCoveringAnyPeriodPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation produced financial statements covering any period within the last 12 months?";

        public FinanicialStatementsCoveringAnyPeriodPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatYouNeedToUploadPage ClickYesForFinancialStatementsCoveringAnyPeriodAndContinue() => FinancialStatementsCoveringAnyPeriodAndContinue("Yes");

        public WhatYouNeedToUploadPage ClickNoForFinancialStatementsCoveringAnyPeriodAndContinue() => FinancialStatementsCoveringAnyPeriodAndContinue("No");

        public FullManagementAccountsPage SelectNoForFinancialStatementsCoveringAnyPeriod_SupportingAndContinue()
        {
            SelectNoAndContinue();
            return new FullManagementAccountsPage(context);
        }

        private WhatYouNeedToUploadPage FinancialStatementsCoveringAnyPeriodAndContinue(string option)
        {
            SelectRadioOptionByText(option);
            Continue();
            return new WhatYouNeedToUploadPage(context);
        }
    }
}
