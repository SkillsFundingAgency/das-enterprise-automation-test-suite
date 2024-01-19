using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class BeenMadeBankruptCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "People in control or any partner organisations been made bankrupt in the last 3 years check";

        public BeenMadeBankruptCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
