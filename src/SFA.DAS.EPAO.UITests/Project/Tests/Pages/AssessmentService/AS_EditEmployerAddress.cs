using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_EditEmployerAddress : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "Edit the address that you’d like us to send the certificate to";

        public AS_EditEmployerAddress(ScenarioContext context) : base(context) => VerifyPage();
    }
}
