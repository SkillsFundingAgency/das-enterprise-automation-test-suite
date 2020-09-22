using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypeOfApprenticeshipTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Type of apprenticeship training";
        private readonly ScenarioContext _context;

        public TypeOfApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public DeliveringTrainingInApprenticeshipStandardsPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(_context);
        }

        public OfferingApprenticeshipFrameworksPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
        {
            SelectPassAndContinueToSubSection();
            return new OfferingApprenticeshipFrameworksPage(_context);
        }
    }
}