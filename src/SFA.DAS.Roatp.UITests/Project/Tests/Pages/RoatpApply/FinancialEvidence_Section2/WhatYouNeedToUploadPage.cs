using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class WhatYouNeedToUploadPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What you need to upload";

        public WhatYouNeedToUploadPage(ScenarioContext context) : base(context) => VerifyPage();

        public UploadOrganisationsFinancialPage ContinueOnWhatYouNeedToUploadForFinancialStatementsAndManagementAccounts()
        {
            Continue();
            return new UploadOrganisationsFinancialPage(context);
        }

        public UploadOrganisationsManagementAccountsPage ContinueOnWhatYouNeedToUploadForManagementAccounts()
        {
            Continue();
            return new UploadOrganisationsManagementAccountsPage(context);
        }

        public UploadManagementAccountsCoveringThreeMonths ContinueOnWhatYouNeedToUploadForManagementAccountsCoveringThreeMonths()
        {
            Continue();
            return new UploadManagementAccountsCoveringThreeMonths(context);
        }
    }
}
