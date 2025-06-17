using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleIncontrolChecks
{
    public class PeopleInControlCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "People in control check";

        public PeopleInControlCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
