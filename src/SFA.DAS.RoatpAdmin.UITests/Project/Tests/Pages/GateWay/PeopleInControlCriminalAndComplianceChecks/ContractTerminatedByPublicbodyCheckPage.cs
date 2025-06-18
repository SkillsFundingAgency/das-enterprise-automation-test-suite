using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class ContractTerminatedByPublicBodyCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Contract terminated by a public body in the last 3 years check";

        public ContractTerminatedByPublicBodyCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
