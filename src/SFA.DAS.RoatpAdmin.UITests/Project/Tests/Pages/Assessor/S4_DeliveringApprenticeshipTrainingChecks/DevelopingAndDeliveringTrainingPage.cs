using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class DevelopingAndDeliveringTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Team responsible for developing and delivering training";
        
        public DevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) { }

        public WhoTheTeamHaveWorkedWithPage SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new WhoTheTeamHaveWorkedWithPage(context);
        }

        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_EP()
        {
            SelectPassAndContinueToSubSection();
            return new SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(context);
        }
    }
}