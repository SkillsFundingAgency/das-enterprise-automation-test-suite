using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class AnnualTurnoverPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Was your organisation's total annual turnover over £75 million for the latest reported financial year?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AnnualTurnoverPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FundingFromEsfaPage SelectYesOnAnnualTurnOverAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new FundingFromEsfaPage(_context);
        }
    }
}
