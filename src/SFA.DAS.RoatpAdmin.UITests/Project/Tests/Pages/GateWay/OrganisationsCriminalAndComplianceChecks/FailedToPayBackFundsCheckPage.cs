using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class FailedToPayBackFundsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Failed to pay back funds in the last 3 years check";

        public FailedToPayBackFundsCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
