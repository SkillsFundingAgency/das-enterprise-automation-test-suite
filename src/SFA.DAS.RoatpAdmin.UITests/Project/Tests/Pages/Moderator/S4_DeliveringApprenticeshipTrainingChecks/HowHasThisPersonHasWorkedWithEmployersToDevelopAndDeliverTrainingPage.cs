using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "How has this person worked with employers to develop and deliver training";

        public OverallManagerForTheTeamPage SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(context);
        }

        public OverallManagerForTheTeamPage SelectFailAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
        {
            SelectFailAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(context);
        }

    }
}