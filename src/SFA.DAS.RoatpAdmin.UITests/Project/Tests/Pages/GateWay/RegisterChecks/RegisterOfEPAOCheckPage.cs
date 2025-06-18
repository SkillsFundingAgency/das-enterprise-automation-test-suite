using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.RegisterChecks
{
    public class RegisterOfEPAOCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Register of end-point assessment organisations (EPAO) check";

        public RegisterOfEPAOCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
