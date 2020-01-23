using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_EditEmployerAddress : EPAO_BasePage
    {
        protected override string PageTitle => "Edit the employer's address";

        public AS_EditEmployerAddress(ScenarioContext context) : base(context) => VerifyPage();
    }
}
