using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class WhatIsTheOutcomeForThisApplicationPage : ModeratorBasePage
    {
        protected override string PageTitle => "What is the outcome for this application?";
        private readonly ScenarioContext _context;

        public WhatIsTheOutcomeForThisApplicationPage(ScenarioContext context) : base(context) => _context = context;

        public ModerationAssessmentCompletePage SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
        {
            SelectRadioOptionByForAttribute("OptionYes");
            Continue();
            return new ModerationAssessmentCompletePage(_context);
        }
    }
}