using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Someone responsible for developing and delivering training";

        public WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(context);
        }

        public WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage SelectFailAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
        {
            SelectFailAndContinueToSubSection();
            return new WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(context);
        }
    }
}