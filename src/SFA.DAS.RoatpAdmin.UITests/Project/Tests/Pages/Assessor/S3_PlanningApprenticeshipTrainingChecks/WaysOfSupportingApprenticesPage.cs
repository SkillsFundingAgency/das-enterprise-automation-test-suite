using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
	public class WaysOfSupportingApprenticesPage : AssessorBasePage
	{
		protected override string PageTitle => "Ways of supporting apprentices";
		private readonly ScenarioContext _context;

		public WaysOfSupportingApprenticesPage(ScenarioContext context) : base(context) => _context = context;

		public OtherWaysOfSupportingApprenticesPage SelectPassAndContinueInWaysOfSupportingApprenticesPage()
		{
			SelectPassAndContinueToSubSection();
			return new OtherWaysOfSupportingApprenticesPage(_context);
		}
	}
}