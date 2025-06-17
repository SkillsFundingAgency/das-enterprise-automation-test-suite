using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class ActingAsASubContractorPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "When acting as a subcontractor, will your organisation follow its lead provider's policies and plans?";

        public ActingAsASubContractorPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectYes()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(context);
        }
    }
}
