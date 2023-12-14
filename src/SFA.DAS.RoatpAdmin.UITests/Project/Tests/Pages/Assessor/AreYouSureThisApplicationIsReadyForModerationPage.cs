using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AreYouSureThisApplicationIsReadyForModerationPage : AssessorBasePage
    {
        protected override string PageTitle => "Are you sure this application is ready for moderation?";

        public AreYouSureThisApplicationIsReadyForModerationPage(ScenarioContext context) : base(context) { }

        public BlindAssessmentCompletePage SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
        {
            SelectRadioOptionByForAttribute("OptionYes");
            Continue();
            return new BlindAssessmentCompletePage(context);
        }
    }
}