using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AreYouSureThisApplicationIsReadyForModerationPage : AssessorBasePage
    {
        protected override string PageTitle => "Are you sure this application is ready for moderation?";
        private readonly ScenarioContext _context;

        public AreYouSureThisApplicationIsReadyForModerationPage(ScenarioContext context) : base(context) => _context = context;

        public BlindAssessmentCompletePage SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
        {
            SelectRadioOptionByForAttribute("OptionYes");
            Continue();
            return new BlindAssessmentCompletePage(_context);
        }
    }
}