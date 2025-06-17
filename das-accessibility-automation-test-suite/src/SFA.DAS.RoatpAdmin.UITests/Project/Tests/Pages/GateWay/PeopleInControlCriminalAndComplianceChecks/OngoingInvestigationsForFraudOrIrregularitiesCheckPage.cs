using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class OngoingInvestigationsForFraudOrIrregularitiesCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Ongoing investigations for fraud or irregularities check";

        public OngoingInvestigationsForFraudOrIrregularitiesCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
