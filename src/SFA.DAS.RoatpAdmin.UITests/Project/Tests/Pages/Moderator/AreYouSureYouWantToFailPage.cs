using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToFailPage : AreYouSurePage
    {
        protected override string PageTitle => "Are you sure you want to fail this application?";

        public AreYouSureYouWantToFailPage(ScenarioContext context) : base(context) { }

        public ModerationAssessmentFailCompletePage SelectYesFailAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentFailCompletePage(context);
        }
    }
}