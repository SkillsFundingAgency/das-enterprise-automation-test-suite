using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class WhatIsTheOutcomeForThisApplicationPage : ModeratorBasePage
    {
        protected override string PageTitle => "What is the outcome for this application?";

        public WhatIsTheOutcomeForThisApplicationPage(ScenarioContext context) : base(context) { }

        public AreYouSureYouWantToPassPage SelectPassAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Pass");
            Continue();
            return new AreYouSureYouWantToPassPage(context);
        }

        public AreYouSureYouWantToFailPage SelectFailAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Fail");
            EnterFailInternalComments();
            Continue();
            return new AreYouSureYouWantToFailPage(context);
        }

        public AreYouSureYouWantToAskPage SelectAskForClarificationAndContinueAreYouSurePage()
        {
            SelectRadioOptionByText("Ask for clarification");
            EnterAskForClarificationInternalComments();
            Continue();
            return new AreYouSureYouWantToAskPage(context);
        }
    }
}