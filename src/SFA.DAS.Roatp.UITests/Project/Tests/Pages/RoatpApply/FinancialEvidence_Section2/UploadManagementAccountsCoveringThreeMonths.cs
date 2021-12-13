using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadManagementAccountsCoveringThreeMonths : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's management accounts covering at least 3 months within the last 12 months";

        public UploadManagementAccountsCoveringThreeMonths(ScenarioContext context) : base(context) => VerifyPage();

        public UploadFinancialProjectionsPage UploadManagementAccountsAndContinue()
        {
            UploadMultipleFiles(4);
            return new UploadFinancialProjectionsPage(_context);
        }
    }
}