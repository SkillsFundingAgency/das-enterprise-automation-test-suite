using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
	public class WaysOfSupportingApprenticesPage : ModeratorBasePage
	{
		protected override string PageTitle => "Ways of supporting apprentices";
		private readonly ScenarioContext _context;

		public WaysOfSupportingApprenticesPage(ScenarioContext context) : base(context) => _context = context;

		public OtherWaysOfSupportingApprenticesPage SelectPassAndContinueInWaysOfSupportingApprenticesPage()
		{
			SelectPassAndContinueToSubSection();
			return new OtherWaysOfSupportingApprenticesPage(_context);
		}

		public OtherWaysOfSupportingApprenticesPage SelectFailAndContinueInWaysOfSupportingApprenticesPage()
		{
			SelectFailAndContinueToSubSection();
			return new OtherWaysOfSupportingApprenticesPage(_context);
		}
	}
}