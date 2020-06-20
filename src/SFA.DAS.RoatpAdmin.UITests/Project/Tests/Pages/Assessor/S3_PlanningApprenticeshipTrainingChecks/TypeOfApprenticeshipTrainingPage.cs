using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypeOfApprenticeshipTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Type of apprenticeship training";
        private readonly ScenarioContext _context;

        public TypeOfApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public DeliveringTrainingInApprenticeshipStandardsPage SelectPassAndContinueInDeliveringTrainingInApprenticeshipStandardsPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(_context);
        }

        public OfferingApprenticeshipFrameworksPage SelectPassAndContinueInDeliveringTrainingInApprenticeshipStandardsPage_SP()
        {
            SelectPassAndContinueToSubSection();
            return new OfferingApprenticeshipFrameworksPage(_context);
        }
    }
}