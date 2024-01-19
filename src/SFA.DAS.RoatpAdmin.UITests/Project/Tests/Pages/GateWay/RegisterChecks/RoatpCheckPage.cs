using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.RegisterChecks
{
    public class RoatpCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "RoATP check";

        public RoatpCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
