using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
	public class WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage : AssessorBasePage
	{
		protected override string PageTitle => "Who the person has worked with to develop and deliver training";
		private readonly ScenarioContext _context;

		public WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(ScenarioContext context) : base(context) => _context = context;

		public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
		{
			SelectPassAndContinueToSubSection();
			return new HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(_context);
		}
	}
}