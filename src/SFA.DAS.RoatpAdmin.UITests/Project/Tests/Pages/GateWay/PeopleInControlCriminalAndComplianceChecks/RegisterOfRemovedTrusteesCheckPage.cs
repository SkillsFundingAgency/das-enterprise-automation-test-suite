using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class RegisterOfRemovedTrusteesCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Register of Removed Trustees check";

        public RegisterOfRemovedTrusteesCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
