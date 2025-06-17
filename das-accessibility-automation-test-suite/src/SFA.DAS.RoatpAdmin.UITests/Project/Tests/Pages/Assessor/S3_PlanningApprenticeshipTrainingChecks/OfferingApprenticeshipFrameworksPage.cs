using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class OfferingApprenticeshipFrameworksPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Offering apprenticeship frameworks";

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(context);
        }
    }
}