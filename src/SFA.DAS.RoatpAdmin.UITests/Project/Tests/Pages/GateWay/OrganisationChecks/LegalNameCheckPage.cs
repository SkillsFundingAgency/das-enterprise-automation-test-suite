using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class LegalNameCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Legal name check";

        public LegalNameCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
