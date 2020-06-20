using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
	public class WhoHasThisPersonHasWorkedWithToDevelopAndDeliverTrainingPage : AssessorBasePage
	{
		protected override string PageTitle => "Who has this person has worked with to develop and deliver training?";
		private readonly ScenarioContext _context;

		public WhoHasThisPersonHasWorkedWithToDevelopAndDeliverTrainingPage(ScenarioContext context) : base(context) => _context = context;

		public HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage SelectPassAndContinueInWhoHasThisPersonHasWorkedWithToDevelopAndDeliverTrainingPage()
		{
			SelectPassAndContinueToSubSection();
			return new HowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage(_context);
		}
	}
}