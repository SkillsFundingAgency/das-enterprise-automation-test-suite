using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FullManagementAccountsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation produced full management accounts covering the last 12 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FullManagementAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhatYouNeedToUploadPage SelectNoForManagementAccountsSupportingRouteAndContinue()
        {
            SelectNoAndContinue();
            return new WhatYouNeedToUploadPage(_context);
        }
    }
}
