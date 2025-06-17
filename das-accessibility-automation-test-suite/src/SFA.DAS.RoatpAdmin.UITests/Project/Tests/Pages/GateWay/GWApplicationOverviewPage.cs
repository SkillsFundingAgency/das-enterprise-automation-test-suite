using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Application assessment overview";

        public GWApplicationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
