using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class OfferingApprenticeshipFrameworksPage : AssessorBasePage
    {
        protected override string PageTitle => "Offering apprenticeship frameworks";
        
        public OfferingApprenticeshipFrameworksPage(ScenarioContext context) : base(context) { }

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(_context);
        }
    }
}