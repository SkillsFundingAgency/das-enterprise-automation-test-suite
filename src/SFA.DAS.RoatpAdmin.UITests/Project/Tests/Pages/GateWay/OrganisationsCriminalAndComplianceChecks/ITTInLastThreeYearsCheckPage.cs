using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class ITTInLastThreeYearsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Involuntary withdrawal from Initial Teacher Training accreditation in the last 3 years check";

        public ITTInLastThreeYearsCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
