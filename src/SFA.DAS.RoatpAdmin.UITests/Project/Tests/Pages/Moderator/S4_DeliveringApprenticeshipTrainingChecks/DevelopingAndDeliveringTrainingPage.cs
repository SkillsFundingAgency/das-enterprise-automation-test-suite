using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class DevelopingAndDeliveringTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Team responsible for developing and delivering training";

        public DevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) { }

        public WhoTheTeamHaveWorkedWithPage SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new WhoTheTeamHaveWorkedWithPage(context);
        }

        public WhoTheTeamHaveWorkedWithPage SelectFailAndContinueInDevelopingAndDeliveringTrainingPage_MP()
        {
            SelectFailAndContinueToSubSection();
            return new WhoTheTeamHaveWorkedWithPage(context);
        }

        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_EP()
        {
            SelectPassAndContinueToSubSection();
            return new SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(context);
        }

        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage SelectFailAndContinueInDevelopingAndDeliveringTrainingPage_EP()
        {
            SelectFailAndContinueToSubSection();
            return new SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(context);
        }
    }
}