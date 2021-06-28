using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class OtherSubsidiaryCompaniesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your UK ultimate parent company have other active subsidiary companies?";

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
