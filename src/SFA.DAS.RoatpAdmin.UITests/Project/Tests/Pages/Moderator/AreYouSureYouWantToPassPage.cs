using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToPassPage : AreYouSurePage
    {
        protected override string PageTitle => "Are you sure you want to pass this application?";

        public AreYouSureYouWantToPassPage(ScenarioContext context) : base(context) { }

        public ModerationAssessmentPassCompletePage SelectYesPassAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentPassCompletePage(_context);
        }
    }
}