using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class SupportingApprenticesPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Supporting apprentices during apprenticeship training";

        public WaysOfSupportingApprenticesPage SelectPassAndContinueInSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(context);
        }
        public ApplicationAssessmentOverviewPage SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(context);
        }
    }
}