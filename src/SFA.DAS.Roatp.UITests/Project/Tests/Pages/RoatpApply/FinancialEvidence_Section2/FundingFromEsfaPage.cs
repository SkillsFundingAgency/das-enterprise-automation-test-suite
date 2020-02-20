using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FundingFromEsfaPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation expect its funding from ESFA to be less than 5% of its total annual turnover?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FundingFromEsfaPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialEvidencePage SelectNoOnFundingFromEsfaAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new FinancialEvidencePage(_context);
        }
    }
}
