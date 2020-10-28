using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentFailCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Fail";

        public ModerationAssessmentFailCompletePage(ScenarioContext context) : base(context) { }

    }
}