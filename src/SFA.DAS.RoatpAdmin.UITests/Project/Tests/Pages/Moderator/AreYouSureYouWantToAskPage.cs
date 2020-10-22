using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToAskPage : ModeratorBasePage
    {
        protected override string PageTitle => "Are you sure you want to ask for clarification?";

        private readonly ScenarioContext _context;

        public AreYouSureYouWantToAskPage(ScenarioContext context) : base(context) => _context = context;


        public ModerationAssessmentClarificationCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectRadioOptionByForAttribute("Yes");
            Continue();
            return new ModerationAssessmentClarificationCompletePage(_context);
        }

    }
}