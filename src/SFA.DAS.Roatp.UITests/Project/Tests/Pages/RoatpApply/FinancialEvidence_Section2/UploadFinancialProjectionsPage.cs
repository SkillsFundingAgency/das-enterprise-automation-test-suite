using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadFinancialProjectionsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's financial projections covering the remaining period";

        public UploadFinancialProjectionsPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhoPreparedAnswersAndUploadPage UploadFinancialProjectionsAndContinue()
        {
            UploadMultipleFiles(3);
            return new WhoPreparedAnswersAndUploadPage(context);
        }
    }
}