using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class OfferingApprenticeshipFrameworksPage : ModeratorBasePage
    {
        protected override string PageTitle => "Offering apprenticeship frameworks";
        private readonly ScenarioContext _context;

        public OfferingApprenticeshipFrameworksPage(ScenarioContext context) : base(context) => _context = context;

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(_context);
        }
    }
}