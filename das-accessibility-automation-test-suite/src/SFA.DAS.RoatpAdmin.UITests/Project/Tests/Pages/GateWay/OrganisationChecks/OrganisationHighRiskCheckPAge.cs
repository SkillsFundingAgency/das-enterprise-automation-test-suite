using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class OrganisationHighRiskCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Organisation high risk check";

        public OrganisationHighRiskCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
