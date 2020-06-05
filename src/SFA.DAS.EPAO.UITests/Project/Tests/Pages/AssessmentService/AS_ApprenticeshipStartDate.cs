using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ApprenticeshipStartDate : AS_GradeDateBasePage
    {
        protected override string PageTitle => "What is the apprenticeship start date?";

        public AS_ApprenticeshipStartDate(ScenarioContext context) : base(context) { }
    }
}
