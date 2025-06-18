using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class ICONumberCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Information Commissioner's Office (ICO) registration number check";

        public ICONumberCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
