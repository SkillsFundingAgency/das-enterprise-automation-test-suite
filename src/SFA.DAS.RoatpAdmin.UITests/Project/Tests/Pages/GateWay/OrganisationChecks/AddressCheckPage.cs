using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class AddressCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Address check";

        public AddressCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
