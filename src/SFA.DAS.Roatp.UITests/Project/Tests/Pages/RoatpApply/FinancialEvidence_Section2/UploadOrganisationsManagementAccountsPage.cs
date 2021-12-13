using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadOrganisationsManagementAccountsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's full management accounts for the last 12 months";

        public UploadOrganisationsManagementAccountsPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhoPreparedAnswersAndUploadPage UploadManagementAccountsFileAndContinue()
        {
            UploadMultipleFiles(2);
            return new WhoPreparedAnswersAndUploadPage(context);
        }
    }
}
