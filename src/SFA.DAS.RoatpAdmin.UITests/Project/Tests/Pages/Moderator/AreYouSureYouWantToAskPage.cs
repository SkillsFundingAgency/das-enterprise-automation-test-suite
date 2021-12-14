using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToAskPage : AreYouSurePage
    {
        protected override string PageTitle => "Are you sure you want to ask for clarification?";

        public AreYouSureYouWantToAskPage(ScenarioContext context) : base(context) { }

        public ModerationAssessmentClarificationCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentClarificationCompletePage(context);
        }

    }
}