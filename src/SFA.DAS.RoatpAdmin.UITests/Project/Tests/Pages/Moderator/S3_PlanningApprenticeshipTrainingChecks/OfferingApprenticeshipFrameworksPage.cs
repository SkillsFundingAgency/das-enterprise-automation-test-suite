using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class OfferingApprenticeshipFrameworksPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Offering apprenticeship frameworks";

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(context);
        }

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectFailAndContinueInOfferingApprenticeshipFrameworksPage()
        {
            SelectFailAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(context);
        }
    }
}