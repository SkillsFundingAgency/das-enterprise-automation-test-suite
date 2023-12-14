using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentFailCompletePage(ScenarioContext context) : ModerationAssessmentCompletePage(context)
    {
        protected override string PageTitle => "Fail";
    }
}