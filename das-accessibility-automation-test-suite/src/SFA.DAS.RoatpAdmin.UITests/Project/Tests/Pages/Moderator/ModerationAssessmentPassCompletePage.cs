using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentPassCompletePage(ScenarioContext context) : ModerationAssessmentCompletePage(context)
    {
        protected override string PageTitle => "Pass";
    }
}