using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToFailPage(ScenarioContext context) : AreYouSurePage(context)
    {
        protected override string PageTitle => "Are you sure you want to fail this application?";

        public ModerationAssessmentFailCompletePage SelectYesFailAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentFailCompletePage(context);
        }
    }
}