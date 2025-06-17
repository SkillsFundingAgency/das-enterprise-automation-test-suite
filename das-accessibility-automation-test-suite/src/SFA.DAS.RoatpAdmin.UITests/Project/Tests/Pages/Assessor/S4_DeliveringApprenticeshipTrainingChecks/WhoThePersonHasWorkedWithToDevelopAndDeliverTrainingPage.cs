using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Who the person has worked with to develop and deliver training";

        public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(context);
        }
    }
}