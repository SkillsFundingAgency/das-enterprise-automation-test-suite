using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentPassCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Pass";
        
        public ModerationAssessmentPassCompletePage(ScenarioContext context) : base(context) { }

    }
}