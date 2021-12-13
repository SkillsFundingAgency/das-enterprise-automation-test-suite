using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class AnExampleOfHowThePolicyToImprovePage : ModeratorBasePage
    {
        protected override string PageTitle => "An example of how the policy is used to improve employee sector expertise";

        public AnExampleOfHowThePolicyToImprovePage(ScenarioContext context) : base(context) { }

        public AnExampleOfHowThePolicyToMaintainPage SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
        {
            SelectPassAndContinueToSubSection();
            return new AnExampleOfHowThePolicyToMaintainPage(context);
        }

        public AnExampleOfHowThePolicyToMaintainPage SelectFailAndContinueInAnExampleOfHowThePolicyToImprovePage()
        {
            SelectFailAndContinueToSubSection();
            return new AnExampleOfHowThePolicyToMaintainPage(context);
        }


        public AnExampleOfHowThePolicyToMaintainPage SelectContinueInAnExampleOfHowThePolicyToImprovePage()
        {
            Continue();
            return new AnExampleOfHowThePolicyToMaintainPage(context);
        }
    }
}