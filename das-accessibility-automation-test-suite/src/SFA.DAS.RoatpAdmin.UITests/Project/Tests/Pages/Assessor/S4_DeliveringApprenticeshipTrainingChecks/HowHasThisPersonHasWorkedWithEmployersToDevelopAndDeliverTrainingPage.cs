using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "How has this person worked with employers to develop and deliver training";

        public OverallManagerForTheTeamPage SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(context);
        }
    }
}