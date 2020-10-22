using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentPassCompletePage : ModerationAssessmentCompletePage
    {
        protected override string PageTitle => "Pass";
        
        private readonly ScenarioContext _context;

        public ModerationAssessmentPassCompletePage(ScenarioContext context) : base(context) => _context = context;

    }
}