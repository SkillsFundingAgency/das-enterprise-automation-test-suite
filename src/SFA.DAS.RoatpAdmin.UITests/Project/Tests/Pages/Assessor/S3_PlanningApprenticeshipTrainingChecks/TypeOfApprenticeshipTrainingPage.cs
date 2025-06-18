using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypeOfApprenticeshipTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Type of apprenticeship training";

        public DeliveringTrainingInApprenticeshipStandardsPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
        {
            SelectPassAndContinueToSubSection();
            return new DeliveringTrainingInApprenticeshipStandardsPage(context);
        }

        public OfferingApprenticeshipFrameworksPage SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
        {
            SelectPassAndContinueToSubSection();
            return new OfferingApprenticeshipFrameworksPage(context);
        }
    }
}