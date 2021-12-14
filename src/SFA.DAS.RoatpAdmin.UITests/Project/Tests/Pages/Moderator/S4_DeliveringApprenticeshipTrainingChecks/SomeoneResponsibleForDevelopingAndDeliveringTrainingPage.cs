using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class SomeoneResponsibleForDevelopingAndDeliveringTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Someone responsible for developing and delivering training";
        
        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) { }

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