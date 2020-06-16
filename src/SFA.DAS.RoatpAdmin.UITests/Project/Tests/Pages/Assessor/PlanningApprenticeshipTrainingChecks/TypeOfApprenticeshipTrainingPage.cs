using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.PlanningApprenticeshipTrainingChecks
{
    public class TypeOfApprenticeshipTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Type of apprenticeship training";
        private readonly ScenarioContext _context;

        public TypeOfApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public DeliveringTrainingInApprenticeshipStandardsPage SelectPassAndContinueInDeliveringTrainingInApprenticeshipStandardsPage()
        {
            SelectPassAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(_context);
        }
    }
}