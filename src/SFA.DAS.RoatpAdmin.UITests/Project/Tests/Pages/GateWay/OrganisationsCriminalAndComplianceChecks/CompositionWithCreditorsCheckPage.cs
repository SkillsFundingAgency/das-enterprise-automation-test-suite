using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class CompositionWithCreditorsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Composition with creditors check";

        public CompositionWithCreditorsCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
