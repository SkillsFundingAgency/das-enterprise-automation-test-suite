using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Someone responsible for developing and delivering training";

        public WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(context);
        }
    }
}