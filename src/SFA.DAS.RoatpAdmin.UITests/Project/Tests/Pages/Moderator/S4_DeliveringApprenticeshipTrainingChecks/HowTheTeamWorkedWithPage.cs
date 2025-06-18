using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class HowTheTeamWorkedWithPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "How the team worked with other organisations to develop and deliver training";

        public OverallManagerForTheTeamPage SelectPassAndContinueInHowTheTeamWorkedWithPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(context);
        }

        public OverallManagerForTheTeamPage SelectFailAndContinueInHowTheTeamWorkedWithPage()
        {
            SelectFailAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(context);
        }
    }
}