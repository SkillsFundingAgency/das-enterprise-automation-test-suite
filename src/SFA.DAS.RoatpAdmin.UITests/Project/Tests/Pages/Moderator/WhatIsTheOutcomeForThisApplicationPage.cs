using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class WhatIsTheOutcomeForThisApplicationPage : ModeratorBasePage
    {
        protected override string PageTitle => "What is the outcome for this application?";
        private readonly ScenarioContext _context;

        public WhatIsTheOutcomeForThisApplicationPage(ScenarioContext context) : base(context) => _context = context;

        public AreYouSureYouWantToPassPage SelectPassAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Pass");
            Continue();
            return new AreYouSureYouWantToPassPage(_context);
        }

        public AreYouSureYouWantToFailPage SelectFailAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Fail");
            EnterFailInternalComments();
            Continue();
            return new AreYouSureYouWantToFailPage(_context);
        }

        public AreYouSureYouWantToAskPage SelectAskForClarificationAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Ask for clarification");
            EnterClarificationInternalComments();
            Continue();
            return new AreYouSureYouWantToAskPage(_context);
        }
    }
}