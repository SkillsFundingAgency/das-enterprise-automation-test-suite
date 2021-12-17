using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CannotFindApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "We cannot find the apprentice details";

        public AS_CannotFindApprenticePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}