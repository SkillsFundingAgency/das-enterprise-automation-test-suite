using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OtherSubsidiaryCompaniesPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your UK ultimate parent company have other subsidiary companies?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OtherSubsidiaryCompaniesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage ClickNoOnOtherSubsidiaryCompanies()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage(_context);
        }
    }
}
