using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class FailedToPayBackFundsPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Failed to pay back funds in the last 3 years check";

        public FailedToPayBackFundsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
