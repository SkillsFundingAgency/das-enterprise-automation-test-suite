using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks
{
    public class SubcontractorDeclarationCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subcontractor declaration check";

        public SubcontractorDeclarationCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
