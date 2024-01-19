using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Who the person has worked with to develop and deliver training";

        public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(context);
        }
        public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage SelectFailAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
        {
            SelectFailAndContinueToSubSection();
            return new HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(context);
        }
    }
}