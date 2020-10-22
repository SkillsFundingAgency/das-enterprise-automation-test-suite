using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentPassCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Pass";
        
        public ModerationAssessmentPassCompletePage(ScenarioContext context) : base(context) { }

    }

    public class ModerationAssessmentFailCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Fail";

        public ModerationAssessmentFailCompletePage(ScenarioContext context) : base(context) { }

    }

    public class ModerationAssessmentClarificationCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Clarification";

        public ModerationAssessmentClarificationCompletePage(ScenarioContext context) : base(context) { }

    }
}