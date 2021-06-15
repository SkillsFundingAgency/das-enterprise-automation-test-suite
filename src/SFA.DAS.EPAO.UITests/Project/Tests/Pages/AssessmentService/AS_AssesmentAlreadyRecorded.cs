using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AssesmentAlreadyRecorded : EPAO_BasePage
    {
        protected override string PageTitle => "An assessment has already been recorded against this apprentice";

        public AS_AssesmentAlreadyRecorded(ScenarioContext context) : base(context) => VerifyPage();
    }
}