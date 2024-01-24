using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AreYouSureThisApplicationIsReadyForModerationPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Are you sure this application is ready for moderation?";

        public BlindAssessmentCompletePage SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
        {
            SelectRadioOptionByForAttribute("OptionYes");
            Continue();
            return new BlindAssessmentCompletePage(context);
        }
    }
}