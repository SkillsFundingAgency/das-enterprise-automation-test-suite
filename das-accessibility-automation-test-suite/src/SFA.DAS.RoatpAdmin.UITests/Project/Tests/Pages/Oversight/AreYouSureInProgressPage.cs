using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureInProgressPage(ScenarioContext context) : AreYouSureAboutApplicationOutcomePage(context)
    {
        protected override string PageTitle => "Are you sure you want to mark this application as 'in progress'?";

        protected override string OversightAssessmentMessage => "In progress";
    }
}
