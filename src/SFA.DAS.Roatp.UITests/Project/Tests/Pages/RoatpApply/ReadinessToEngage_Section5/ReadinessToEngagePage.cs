using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class ReadinessToEngagePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Readiness to engage";

        public ReadinessToEngagePage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
