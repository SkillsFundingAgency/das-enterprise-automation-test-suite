using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class ContractWithPublicBodyCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Withdrawn from a contract with a public body in the last 3 years check";

        public ContractWithPublicBodyCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
