using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureInProgressForAppealPage : AreYouSureAboutApplicationOutcomePage
    {
        protected override string PageTitle => "Are you sure you want to mark this appeal as 'in progress'?";

        protected override string OversightAssessmentMessage => "In progress";

        public AreYouSureInProgressForAppealPage(ScenarioContext context) : base(context) { }
    }
}
