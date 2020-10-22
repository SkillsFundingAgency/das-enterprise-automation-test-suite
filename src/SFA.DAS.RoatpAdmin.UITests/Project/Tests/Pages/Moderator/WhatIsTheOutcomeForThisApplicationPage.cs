using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class AreYouSurePage : ModeratorBasePage
    {
        protected override string PageTitle => "Are you sure you want to pass this application?";

        private readonly ScenarioContext _context;

        public AreYouSurePage(ScenarioContext context) : base(context) => _context = context;

        public ModerationAssessmentPassCompletePage SelectYesAndContinueOutcomePage()
        {
            SelectRadioOptionByForAttribute("Yes");
            Continue();
            return new ModerationAssessmentPassCompletePage(_context);
        }
    }

    public class WhatIsTheOutcomeForThisApplicationPage : ModeratorBasePage
    {
        protected override string PageTitle => "What is the outcome for this application?";
        private readonly ScenarioContext _context;

        public WhatIsTheOutcomeForThisApplicationPage(ScenarioContext context) : base(context) => _context = context;

        public AreYouSurePage SelectPassAndContinueAreYouSurePage()
        {
            SelectRadioOptionByForAttribute("OptionPass");
            Continue();
            return new AreYouSurePage(_context);
        }
    }
}