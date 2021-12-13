using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadOrganisationsFinancialPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's financial statements covering any period within the last 12 months";      

        public UploadOrganisationsFinancialPage(ScenarioContext context) : base(context) => VerifyPage();

        public UploadOrganisationsManagementAccountsPage UploadFinancialFileAndContinue()
        {
            UploadMultipleFiles(3);
            return new UploadOrganisationsManagementAccountsPage(_context);
        }

        public UploadOrganisationsManagementCoveringRemainingPeriodAccountsPage UploadFinancialFileForRemainingPeriodAndContinue()
        {
            UploadMultipleFiles(3);
            return new UploadOrganisationsManagementCoveringRemainingPeriodAccountsPage(_context);
        }
    }
}
