using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FinancialHealthAssessmentPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Financial health assessment";

        public FinancialHealthAssessmentPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ContinueOnFinancialHealthAssessment()
        {
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
