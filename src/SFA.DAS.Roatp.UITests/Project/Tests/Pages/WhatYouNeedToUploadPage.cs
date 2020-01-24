using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhatYouNeedToUploadPage : RoatpBasePage
    {
        protected override string PageTitle => "What you need to upload";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatYouNeedToUploadPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public UploadOrganisationsFinancialPage ContinueOnWhatYouNeedToUploadForFinancialStatementsAndManagementAccounts()
        {
            Continue();
            return new UploadOrganisationsFinancialPage(_context);
        }

    }
}
