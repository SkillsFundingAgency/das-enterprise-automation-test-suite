using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToAskPage(ScenarioContext context) : AreYouSurePage(context)
    {
        protected override string PageTitle => "Are you sure you want to ask for clarification?";

        public ModerationAssessmentClarificationCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentClarificationCompletePage(context);
        }

    }
}