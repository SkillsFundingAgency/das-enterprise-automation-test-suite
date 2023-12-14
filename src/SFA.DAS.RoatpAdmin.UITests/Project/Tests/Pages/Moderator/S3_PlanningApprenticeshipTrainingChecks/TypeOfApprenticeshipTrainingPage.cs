using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypeOfApprenticeshipTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Type of apprenticeship training";

        public DeliveringTrainingInApprenticeshipStandardsPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(context);
        }
        public DeliveringTrainingInApprenticeshipStandardsPage SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_MP()
        {
            SelectFailAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(context);
        }

        public OfferingApprenticeshipFrameworksPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
        {
            SelectPassAndContinueToSubSection();
            return new OfferingApprenticeshipFrameworksPage(context);
        }

        public OfferingApprenticeshipFrameworksPage SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_SP()
        {
            SelectFailAndContinueToSubSection();
            return new OfferingApprenticeshipFrameworksPage(context);
        }
    }
}