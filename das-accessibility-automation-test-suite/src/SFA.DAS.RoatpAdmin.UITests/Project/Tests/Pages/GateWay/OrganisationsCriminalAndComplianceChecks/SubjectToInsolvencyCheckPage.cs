using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class SubjectToInsolvencyCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subject to insolvency or winding up proceedings in the last 3 years check";

        public SubjectToInsolvencyCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
