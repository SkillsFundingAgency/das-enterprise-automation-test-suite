using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ConsolidatedFinancialStatementsPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your UK ultimate parent company have consolidated financial statements?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConsolidatedFinancialStatementsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public OtherSubsidiaryCompaniesPage ClickNoOnConsolidatedFinancialStatements()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new OtherSubsidiaryCompaniesPage(_context);
        }
    }
}
