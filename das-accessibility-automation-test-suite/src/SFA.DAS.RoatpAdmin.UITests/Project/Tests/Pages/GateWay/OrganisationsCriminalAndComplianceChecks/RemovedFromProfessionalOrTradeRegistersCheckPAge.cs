using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class RemovedFromProfessionalOrTradeRegistersCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Removed from any professional or trade registers in the last 3 years check";

        public RemovedFromProfessionalOrTradeRegistersCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
