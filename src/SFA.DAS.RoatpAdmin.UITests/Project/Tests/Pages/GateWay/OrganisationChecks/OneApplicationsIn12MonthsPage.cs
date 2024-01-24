using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class OneApplicationsIn12MonthsPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "One application in 12 months check";

        public OneApplicationsIn12MonthsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
