using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToPassPage : AreYouSurePage
    {
        protected override string PageTitle => "Are you sure you want to pass this application?";

        private readonly ScenarioContext _context;

        public AreYouSureYouWantToPassPage(ScenarioContext context) : base(context) => _context = context;

        public ModerationAssessmentPassCompletePage SelectYesPassAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentPassCompletePage(_context);
        }
    }
}