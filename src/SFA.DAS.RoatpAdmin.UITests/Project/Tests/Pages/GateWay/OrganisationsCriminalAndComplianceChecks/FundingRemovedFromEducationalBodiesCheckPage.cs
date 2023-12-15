using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class FundingRemovedFromEducationalBodiesCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Funding removed from any education bodies in the last 3 years check";

        public FundingRemovedFromEducationalBodiesCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
