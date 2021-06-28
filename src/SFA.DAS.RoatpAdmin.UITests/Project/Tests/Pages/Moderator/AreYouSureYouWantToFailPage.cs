using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToFailPage : AreYouSurePage
    {
        protected override string PageTitle => "Are you sure you want to fail this application?";

        private readonly ScenarioContext _context;

        public AreYouSureYouWantToFailPage(ScenarioContext context) : base(context) => _context = context;


        public ModerationAssessmentFailCompletePage SelectYesFailAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentFailCompletePage(_context);
        }
    }
}