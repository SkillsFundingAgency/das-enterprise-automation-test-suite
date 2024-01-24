using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class WhoTheTeamHaveWorkedWithPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Who the team have worked with to develop and deliver training";

        public HowTheTeamWorkedWithPage SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowTheTeamWorkedWithPage(context);
        }

        public HowTheTeamWorkedWithPage SelectFailAndContinueInWhoTheTeamHaveWorkedWithPage()
        {
            SelectFailAndContinueToSubSection();
            return new HowTheTeamWorkedWithPage(context);
        }
    }
}