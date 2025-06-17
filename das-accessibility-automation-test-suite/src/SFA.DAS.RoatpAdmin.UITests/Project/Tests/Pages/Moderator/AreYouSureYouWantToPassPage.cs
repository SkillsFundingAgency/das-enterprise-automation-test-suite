using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSureYouWantToPassPage(ScenarioContext context) : AreYouSurePage(context)
    {
        protected override string PageTitle => "Are you sure you want to pass this application?";

        public ModerationAssessmentPassCompletePage SelectYesPassAndContinueOutcomePage()
        {
            SelectYesAndContinue();
            return new ModerationAssessmentPassCompletePage(context);
        }
    }
}