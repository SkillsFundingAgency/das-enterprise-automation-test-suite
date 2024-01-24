using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class ContractTerminatedEarlyCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Contract terminated early by a public body in the last 3 years check";

        public ContractTerminatedEarlyCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
