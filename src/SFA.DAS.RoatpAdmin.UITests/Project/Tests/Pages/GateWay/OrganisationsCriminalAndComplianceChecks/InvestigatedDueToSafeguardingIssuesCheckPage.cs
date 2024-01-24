using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class InvestigatedDuetoSafeguardingIssuesCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Investigated due to safeguarding issues in the last 3 months check";

        public InvestigatedDuetoSafeguardingIssuesCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
