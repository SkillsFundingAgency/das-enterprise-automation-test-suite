using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadManagementAccountsCoveringThreeMonths : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation’s management accounts showing between 6 to 12 months of actual trading activity";

        public UploadManagementAccountsCoveringThreeMonths(ScenarioContext context) : base(context) => VerifyPage();

        public UploadFinancialProjectionsPage UploadManagementAccountsAndContinue()
        {
            UploadMultipleFiles(4);
            return new UploadFinancialProjectionsPage(context);
        }
    }
}