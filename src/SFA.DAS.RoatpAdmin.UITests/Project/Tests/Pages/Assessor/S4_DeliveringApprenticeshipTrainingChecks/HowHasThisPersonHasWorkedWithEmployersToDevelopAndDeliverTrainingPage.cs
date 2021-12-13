using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
	public class HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage : AssessorBasePage
	{
		protected override string PageTitle => "How has this person worked with employers to develop and deliver training";
		
		public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(ScenarioContext context) : base(context) { }

		public OverallManagerForTheTeamPage SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
		{
			SelectPassAndContinueToSubSection();
			return new OverallManagerForTheTeamPage(context);
		}
	}
}