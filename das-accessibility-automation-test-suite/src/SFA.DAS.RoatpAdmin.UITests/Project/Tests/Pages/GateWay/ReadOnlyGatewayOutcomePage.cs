using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class ReadOnlyGatewayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Gateway outcome";

        public ReadOnlyGatewayOutcomePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
